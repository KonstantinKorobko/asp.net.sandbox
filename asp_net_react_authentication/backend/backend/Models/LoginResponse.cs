using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class LoginResponse
    {
        [Required]
        public string? JWT { get; set; }
        //[Required]
        //public Guid Id { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
