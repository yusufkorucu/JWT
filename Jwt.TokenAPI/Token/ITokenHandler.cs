namespace Jwt.TokenAPI.Token
{
    public interface ITokenHandler
    {
        Dto.Token CreateToken();
    }
}
