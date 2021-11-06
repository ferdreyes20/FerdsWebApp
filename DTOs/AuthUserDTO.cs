using System.ComponentModel.DataAnnotations;

namespace FerdsWebApp.DTOs
{
    public class AuthUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}