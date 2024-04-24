namespace dotnet_api.Services
{
    using dotnet_api.Model;

    public interface ILogRequestService
    {
        void LogRequest(RequestLog log);
    }
}