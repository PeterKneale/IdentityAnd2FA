using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Demo.Services.Email;

namespace Demo.Web.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            System.Diagnostics.Debug.WriteLine($"Verification Link: {link}");
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
