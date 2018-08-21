using System.Threading.Tasks;

namespace PluralsightLive.Application.Services
{
    public class MailService : IMailService
    {
        public Task SendSuccessMessageToStudent(string name, string email)
        {
            return Task.CompletedTask; // Fake return
        }
    }
}