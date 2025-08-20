using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IEmailService
    {
        Task SendEmail(ContactViewModel contactViewModel);
    }
}
