using Microsoft.EntityFrameworkCore;
using mclog_API.Models;
namespace mclog_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<UserModel> users { get; set; }

        public DbSet<ActivityLogsModel> activityLogs { get; set; }

        public DbSet<UserHealthStatusModel> userHealthStatus { get; set; }

        public DbSet<AuthenticationModel> authenticationModel { get; set; }

        public DbSet<GetUserLogs> getUserLogs { get; set; }

        public DbSet<mclog_API.Models.SymptomsModel> symptoms { get; set; }

        public DbSet<mclog_API.Models.BuildingsModel> buildings { get; set; }

        public DbSet<mclog_API.Models.AdminModel> adminModels { get; set; }
    }
}
