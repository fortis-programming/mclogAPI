namespace mclog_API.Models
{
    public class BuildingModel
    {
        public int Id { get; set; }

        public string? BuildingName { get; set; }

        public string? Address { get; set; }

        public int ActivityLogId { get; set; }

        public DateTime? TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        
    }
}
