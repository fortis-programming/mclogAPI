using System.ComponentModel.DataAnnotations;

namespace mclog_API.Models
{
    public class ActivityLogsModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? Status { get; set; }

        public DateTime ActivityDate { get; set; }

        public int HealthStatusId { get; set; }

        public int BuildingId { get; set; }

    }
}