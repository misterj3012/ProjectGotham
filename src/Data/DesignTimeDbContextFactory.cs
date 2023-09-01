using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProjectGotham.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GothamDbContext>
    {
        public GothamDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<GothamDbContext> builder = new DbContextOptionsBuilder<GothamDbContext>();
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString, new MySqlServerVersion(new Version(11, 1, 2))); // Adjust the version accordingly

            return new GothamDbContext(builder.Options);
        }
    }
}
