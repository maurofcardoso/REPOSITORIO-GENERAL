namespace Application.Interfaces.SendEmails
{
    public interface ISendEmail
    {
        Task GetEmail(string email, string name);
    }
}
