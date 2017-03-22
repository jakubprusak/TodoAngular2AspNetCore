using System.Threading.Tasks;

namespace TodoAngular2AspNetCore.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
