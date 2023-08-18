using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class IdByEmail
    {
        [Key]
        [Required]
        public string? Email { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}
