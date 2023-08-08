using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class UserAuthent
    {
        [Key]
        [Required]        
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}
