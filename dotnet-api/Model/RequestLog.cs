namespace dotnet_api.Model
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string JsonRequest { get; set; }
        public string JsonResponse { get; set; }
    }
}