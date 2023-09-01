using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Extensions.Logging;
using ProjectGotham.Controllers;
using ProjectGotham.Data;
using ProjectGotham.Data.Repositories;
using ProjectGotham.Data.Repositories.Interfaces;
using ProjectGotham.Factories;
using ProjectGotham.Services;
using ProjectGotham.Services.Interfaces;
using ProjectGotham.Utilities;
using Prometheus;

namespace ProjectGotham
{

    public class StartUp : AsyncResource
    {
        // Configuration and service-related properties
        public IConfiguration Configuration { get; private set; }
        public IServiceCollection Services { get; private set; } = new ServiceCollection();
        public IServiceProvider? ServiceProvider { get; set; }
        public string EnvironmentName { get; set; }
        public MetricServer metricServer;

        // Timed actions for regular checks
        private List<TimerAction> _timedActions;
        bool shouldSeedData;

        public override void OnTick()
        {
            DateTime currentTime = DateTime.UtcNow;

            foreach (TimerAction action in _timedActions)
            {
                action.TryExecute(currentTime);
            }
        }
        public override void OnStart()
        {
            Alt.OnServerStarted += OnServerStarted;

            Initialize();
            ConfigureLogging();
            RegisterServices();
            StartMetricsServer();
            RegisterTimers();
        }
        private void Initialize()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true, reloadOnChange: true);

            Configuration = configBuilder.Build();
        }
        private void ConfigureLogging()
        {
            NLog.LogManager.Configuration = new NLogLoggingConfiguration(Configuration.GetSection("NLog"));
        }

        private void RegisterServices()
        {
            Services.AddDbContext<GothamDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(11, 1, 2))));

            Services.AddSingleton<ILoggingService, LoggingService>();

            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddTransient<IAccountRepository, AccountRepository>();
            Services.AddTransient<ICharacterRepository, CharacterRepository>();
            Services.AddTransient<IVehicleRepository, VehicleRepository>();

            Services.AddTransient<IAccountService, AccountService>();
            Services.AddTransient<ICharacterService, CharacterService>();
            Services.AddTransient<IVehicleService, VehicleService>();

            Services.AddTransient<AccountController>();
            Services.AddTransient<CharacterController>();
            Services.AddTransient<VehicleController>();

            if (!bool.TryParse(Configuration["SeedData"], out bool seedDataResult))
            {
                seedDataResult = false;
            }
            shouldSeedData = seedDataResult;
            if (shouldSeedData)
            {
                Services.AddTransient<Seeding>();
            }

            ServiceProvider = Services.BuildServiceProvider();
        }
        private void StartMetricsServer()
        {
            string metricServerHost = Configuration["MetricServer:Hostname"] ?? "localhost";
            if (!int.TryParse(Configuration["MetricServer:Port"], out int portResult))
            {
                portResult = 12345;
            }
            int metricServerPort = portResult;
            metricServer = new MetricServer(hostname: metricServerHost, port: metricServerPort);
            metricServer.Start();
        }
        private void RegisterTimers()
        {
            _timedActions = new List<TimerAction>
            {
                new TimerAction(() =>
                {
                   // Do something
                }, 60)
            };
        }
        public async void OnServerStarted()
        {
            if (shouldSeedData)
            {
                await InvokeServiceAsync<Seeding>(s => s.Seed());
            }
            await InvokeServiceAsync<IAccountService>(s => s.CheckAllAccounts());
            await InvokeServiceAsync<ICharacterService>(s => s.CheckAllCharacters());
            await InvokeServiceAsync<IVehicleService>(s => s.LoadAndSpawnAllVehicles());
        }
        private async Task InvokeServiceAsync<T>(Func<T, Task> action) where T : class
        {
            T? service = ServiceProvider.GetService<T>();
            if (service != null)
            {
                try
                {
                    await action(service);
                }
                catch (Exception ex)
                {
                    LogManager.GetCurrentClassLogger().Error(ex, "Error while invoking service");
                }
            }
            else
            {
                LogManager.GetCurrentClassLogger().Error("Service not found while invoking");
            }
        }
        public override IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new CharacterFactory();
        }
        public override IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new VehicleFactory();
        }
        public override void OnStop()
        {
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
            LogManager.Shutdown();
            metricServer.Stop();
        }
    }
}