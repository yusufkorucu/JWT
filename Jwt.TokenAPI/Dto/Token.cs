namespace Jwt.TokenAPI.Dto
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
