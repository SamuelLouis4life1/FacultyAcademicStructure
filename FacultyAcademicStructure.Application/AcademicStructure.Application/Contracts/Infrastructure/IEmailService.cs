using AcademicStructure.Application.Models;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
