using Application.Interfaces.SendEmails;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Application.Tools
{
    public class SendEmail : ISendEmail
    {
        private readonly ISendGridClient _sendGripClient;
        private readonly IConfiguration _configuration;

        public SendEmail(ISendGridClient sendGripClient, IConfiguration configuration)
        {
            _sendGripClient = sendGripClient;
            _configuration = configuration;
        }

        public async Task GetEmail (string email, string name)
        {
            //string fromEmail = _configuration.GetSection("SendGridSettings").GetValue<string>("fromEmail");
            //string fromName = _configuration.GetSection("SendGridSettings").GetValue<string>("fromName");
            //var messageSend = new SendGridMessage()
            //{
            //    From = new EmailAddress(fromEmail, fromName),
            //    Subject = "Welcome at disney",
            //    PlainTextContent = "Hello, WellCome!!!"
            //};
            //messageSend.AddTo(email);
            //await _sendGripClient.SendEmailAsync(messageSend);
            //hasta aca
            //var apiKey = Environment.GetEnvironmentVariable("APIkey");
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("test@example.com", "Example User");
            var apiKey = _configuration.GetSection("SendGridSettings").GetValue<string>("APIkey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration.GetSection("SendGridSettings").GetValue<string>("fromEmail"), _configuration.GetSection("SendGridSettings").GetValue<string>("fromName"));
            var subject = "WellcomeDisney";
            var to = new EmailAddress(email, name);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
