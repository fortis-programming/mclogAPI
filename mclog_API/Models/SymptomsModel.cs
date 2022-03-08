namespace mclog_API.Models
{
    public class SymptomsModel
    {
        public int Id { get; set; }

        public string? SymptomName { get; set; }

        public int UserHealthStatusId { get; set; }
    }
}
