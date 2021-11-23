using AcademicStructure.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AcademicStructure.Application.Contracts.Persistence
{
    public interface ITeacherRepository : IAsyncRepository<Teacher>
    {
        Task<IEnumerable<Teacher>> GetTeacherByName(string teacherName);
    }
}
