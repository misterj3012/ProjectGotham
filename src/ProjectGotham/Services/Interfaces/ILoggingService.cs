namespace ProjectGotham.Services.Interfaces
{
    public interface ILoggingService
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogDebug(string message);
    }
}
