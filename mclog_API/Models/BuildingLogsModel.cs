namespace mclog_API.Models
{
    public class BuildingLogsModel
    {
        public int id { get; set; }

        public DateTime? TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public int ActivityLogId { get; set; }

        public int BuildingId { get; set; }
    }
}
