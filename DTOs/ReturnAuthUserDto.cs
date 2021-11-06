namespace FerdsWebApp.DTOs
{
    public class ReturnAuthUserDto : UserDto
    {
        public string Error { get; set; }
        public string Token { get; set; }
    }
}