using Portfolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portfolio.Services
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(ContactViewModel contactViewModel)
        {
            // Getting configuration variables

            var senderEmail = configuration.GetValue<string>("EmailConfigurations:Email");
            var password = configuration.GetValue<string>("EmailConfigurations:Password");
            var host = configuration.GetValue<string>("EmailConfigurations:Host");
            var port = configuration.GetValue<int>("EmailConfigurations:Port");

            // Configuration smtpClient 

            SmtpClient smtpClient = new(host, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, password)
            };

            // Creating email message

            MailMessage message = new(senderEmail!, senderEmail!,
                $"El cliente {contactViewModel.Name} ({contactViewModel.Email}) quiere contactarte",
                contactViewModel.Message);

            await smtpClient.SendMailAsync(message);

        }
    }
}
