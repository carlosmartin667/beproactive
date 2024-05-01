namespace ApiDevBP.Services
{
    public interface IGenerateJwtToken
    {
        string JwtToken(string Email);
    }
}
