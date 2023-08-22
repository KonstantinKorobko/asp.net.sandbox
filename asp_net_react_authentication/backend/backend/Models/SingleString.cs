using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class SingleString
    {
        [Required]
        public string? Data { get; set; }
    }
}
