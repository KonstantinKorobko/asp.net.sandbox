using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class AuthUser
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
