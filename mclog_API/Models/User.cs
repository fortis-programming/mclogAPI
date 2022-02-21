namespace mclog_API.Models
{
    public class User
    { 
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public int BirthDate { get; set; }

        public string? Province { get; set; }

        public string? Region { get; set; } 

        public string? City { get; set; }   

        public string? Baranggay { get; set; } 

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }
    }
}
