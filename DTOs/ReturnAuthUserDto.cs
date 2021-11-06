namespace FerdsWebApp.DTOs
{
    public class ReturnAuthUserDto
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string[] Roles { get; set; }
        public string Error { get; set; }
    }
}