namespace Jwt.UserAPI.Dto
{
    public class AuthDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
