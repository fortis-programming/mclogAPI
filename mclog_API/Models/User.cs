using System.ComponentModel.DataAnnotations;

namespace mclog_API.Models
{
    public class User
    { 
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string Gender { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
