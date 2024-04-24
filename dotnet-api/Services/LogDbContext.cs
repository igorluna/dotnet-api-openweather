namespace dotnet_api.Services
{
    using dotnet_api.Model;
    using Microsoft.EntityFrameworkCore;

    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options): base(options){
        }

        public DbSet<RequestLog> RequestLog { get; set; }
    }
}