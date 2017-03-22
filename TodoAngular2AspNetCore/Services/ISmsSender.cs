using System.Threading.Tasks;

namespace TodoAngular2AspNetCore.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
