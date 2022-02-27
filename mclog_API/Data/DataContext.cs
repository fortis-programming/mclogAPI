using Microsoft.EntityFrameworkCore;
using mclog_API.Models;
namespace mclog_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<User> Users { get; set; }

        public DbSet<ActivityLogs> activityLogs { get; set; }

        public DbSet<UserHealthStatus> userHealthStatus { get; set; }

        public DbSet<AuthenticationModel> authenticationModel { get; set; }
    }
}
