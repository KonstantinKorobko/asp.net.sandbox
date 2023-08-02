using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AppUser
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstMidName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifitedDate { get; set; } = DateTime.Now;
    }
}
