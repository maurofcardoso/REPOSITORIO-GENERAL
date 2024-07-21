namespace Aplication.Interfaces.Helpers
{
    public interface IAuthorizer
    {
        string HashPassword(string pass);
        string GenerateToken(IPayload payload);
    }
}
