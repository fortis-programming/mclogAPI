using System.ComponentModel.DataAnnotations.Schema;

namespace mclog_API.Models
{
    public class GetUserLogs
    {
        public int? Id { get; set; }

        public string? Gender { get; set; }

        public string? SymptomName { get; set; }

        public string? Status { get; set; } 

        public DateTime? ActivityDate { get; set; }

        public string? BuildingName { get; set; }

        public string? Address { get; set; }
    }
}
