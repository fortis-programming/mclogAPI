using Microsoft.EntityFrameworkCore;
using mclog_API.Models;
namespace mclog_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<UserModel> Users { get; set; }

        public DbSet<ActivityLogsModel> activityLogs { get; set; }

        public DbSet<UserHealthStatusModel> userHealthStatus { get; set; }

        public DbSet<AuthenticationModel> authenticationModel { get; set; }
    }
}
