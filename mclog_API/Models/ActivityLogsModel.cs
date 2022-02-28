using System.ComponentModel.DataAnnotations;

namespace mclog_API.Models
{
    public class ActivityLogsModel
    {
        public int Id { get; set; }

        public string? Status { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime ActivityDate { get; set; }
    }
}