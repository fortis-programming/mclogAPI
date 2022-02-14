using System.ComponentModel.DataAnnotations;

namespace mclog_API.Models
{
    public class ActivityLogs
    {
        public int Id { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }

        public string? BuildingName { get; set; }
        
        public string? Status { get; set; } 

        public string? UserId { get; set; }

    }
}