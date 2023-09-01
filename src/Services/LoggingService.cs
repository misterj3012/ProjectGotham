using ProjectGotham.Services.Interfaces;

namespace ProjectGotham.Services
{
    public class LoggingService : ILoggingService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        public void LogError(string message)
        {
            Logger.Error(message);
        }

        public void LogDebug(string message)
        {
            Logger.Debug(message);
        }
    }
}
