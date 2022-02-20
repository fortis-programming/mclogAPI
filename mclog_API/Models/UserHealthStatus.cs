using System.ComponentModel.DataAnnotations;

namespace mclog_API.Models
{
    public class UserHealthStatus
    {
        public int Id { get; set; }

        public string? SymptomOne { get; set; }

        public string? SymptomTwo { get; set; }

        public string? SymptomThree { get; set; }

        public string? SymptomFour { get; set; }

        public DateTime? Date { get; set; }

        public string? UserId { get; set; }
    }
}
