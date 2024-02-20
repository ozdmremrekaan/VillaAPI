namespace MagicVilla_Web.Models.Dto.Auth
{
    public class LoginResponseDto
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
