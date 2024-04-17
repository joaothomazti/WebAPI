using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class User
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "The name field is mandatory")]
        [StringLength(50, ErrorMessage = "The name field must have a maximum of 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The email field is mandatory")]
        [EmailAddress(ErrorMessage = "The email field must be filled with a valid email")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
