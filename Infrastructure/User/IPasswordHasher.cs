namespace Infrastructure.User;

public interface IPasswordHasher
{
    public string GenerateHash(string password);
}