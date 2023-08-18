using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class IdByUserName
    {
        [Key]
        [Required]        
        public string? UserName { get; set; }       
        [Required]
        public Guid Id { get; set; }
    }
}
