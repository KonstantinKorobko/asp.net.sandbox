using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FastUserName
    {
        [Key]
        [Required]
        public string? UserName { get; set; }
    }
}
