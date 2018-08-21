using System.Threading.Tasks;

namespace PluralsightLive.Application.Services
{
    public interface IMailService
    {
        Task SendSuccessMessageToStudent(string name, string email);
    }
}