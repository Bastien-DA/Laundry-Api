namespace Api.Jwt;

public interface IJwtToken
{
    public string GenerateJwtToken(string userId);
}