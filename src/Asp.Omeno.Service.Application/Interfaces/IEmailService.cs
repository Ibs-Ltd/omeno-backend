using Asp.Omeno.Service.Application.Models;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Interfaces
{
    public interface IEmailService
    {
        Task Send(EmailModel model);
    }
}
