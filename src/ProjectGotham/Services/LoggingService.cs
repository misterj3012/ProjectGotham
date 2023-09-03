using ProjectGotham.Services.Interfaces;
using Serilog;

namespace ProjectGotham.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public LoggingService()
        {
            _logger = Log.ForContext<LoggingService>();
        }

        public void LogInfo(string message)
        {
            _logger.Information(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }
    }
}