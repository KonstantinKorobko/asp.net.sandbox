using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FastEmail
    {
        [Required]
        public string? Email { get; set; }
    }
}
