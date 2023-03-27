using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class UserRequest
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
