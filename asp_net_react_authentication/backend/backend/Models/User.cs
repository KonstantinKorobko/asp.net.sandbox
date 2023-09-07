using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace backend.Models
{
    public class User
    {
        public User(){}
        public User(AppUser app_user)
        {
            UserName = app_user.UserName;
            Email = app_user.Email;
            FirstMidName = app_user.FirstMidName;
            LastName = app_user.LastName;
            Role = app_user.Role;
            CreatedDate = app_user.CreatedDate;
            ModifitedDate = app_user.ModifitedDate;
        }

        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? FirstMidName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifitedDate { get; set; }
    }
}
