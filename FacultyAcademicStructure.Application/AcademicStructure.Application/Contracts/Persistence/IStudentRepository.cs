using AcademicStructure.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AcademicStructure.Application.Contracts.Persistence
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentsByName(string studentName);
    }
}
