namespace BlogApplication.DataAccess.Models.DTO.Security
{
    public class LoginResponseDTO
    {
        public AuthSecurity User { get; set; }
        public string Token { get; set; }
    }
}
