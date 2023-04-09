using System.Net.Mail;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEmailServices
    {
        Task<bool> SendEmailWithPdf(string ToName, string ToEmail);
        Task<bool> SendConfirmEmail(string ToName, string ToEmail, string Token);
        Task<bool> SendEmail(MailMessage Body);
        Task<bool> SendForgotEmailAsync(string ToName, string ToEmail, string Token);
        Task<bool> SendOPTEmail(string ToName, string ToEmail, string opt);
    }
}
