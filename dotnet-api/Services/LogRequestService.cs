namespace dotnet_api.Services
{
    using dotnet_api.Model;

    public class LogRequestService : ILogRequestService
    {
        private readonly LogDbContext _logContext;
        public LogRequestService(LogDbContext logContext)
        {
            _logContext = logContext;
        }

        public void LogRequest(RequestLog log)
        {
            _logContext.RequestLog.Add(log);
            _logContext.SaveChanges();
        }
    }
}