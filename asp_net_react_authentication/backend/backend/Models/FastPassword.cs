using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FastPassword
    {
        [Required]
        public string? Password { get; set; }
    }
}
