using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Demo.Services.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _log;

        public EmailSender(ILogger<EmailSender> log)
        {
            _log = log;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            _log.LogInformation($"{email} - {subject} - {message}");
            return Task.CompletedTask;
        }
    }
}
