//using Microsoft.AspNetCore.Mvc;
//using SendGrid;
//using SendGrid.Helpers.Mail;

//namespace ProyectoAlkemy.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class SendEmailController : ControllerBase
//    {
//        private readonly ISendGridClient _sendGripClient;
//        private readonly IConfiguration _configuration;

//        public SendEmailController(ISendGridClient sendGripClient, IConfiguration configuration)
//        {
//            _sendGripClient = sendGripClient;
//            _configuration = configuration;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetEmail (string Email)
//        {
//            string fromEmail = _configuration.GetSection("SendGridSettings").GetValue<string>("fromEmail");
//            string fromName = _configuration.GetSection("SendGridSettings").GetValue<string>("fromName");
//            var messageSend = new SendGridMessage()
//            {
//                From = new EmailAddress(fromEmail, fromName),
//                Subject = "Welcome at disney",
//                PlainTextContent = "Hello, WellCome!!!"
//            };
//            messageSend.AddTo(Email);
//            var response = await _sendGripClient.SendEmailAsync(messageSend);
//            string message = response.IsSuccessStatusCode ? "Email Send Successfully" :"Email Sending Failed";
//            return Ok(message);
//        }
//    }
//}
