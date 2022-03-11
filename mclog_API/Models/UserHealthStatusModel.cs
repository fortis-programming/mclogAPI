namespace mclog_API.Models
{
    public class UserHealthStatusModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public string? Status { get; set; }

        public int Temperature { get; set; }
    }
}
