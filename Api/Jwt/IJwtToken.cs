namespace Controllers.Jwt;

public interface IJwtToken
{
    public string GenerateJwtToken(string userId);
}