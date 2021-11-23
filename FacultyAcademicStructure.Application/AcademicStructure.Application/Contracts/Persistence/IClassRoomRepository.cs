using AcademicStructure.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AcademicStructure.Application.Contracts.Persistence
{
    public interface IClassRoomRepository : IAsyncRepository<ClassRoom>
    {
        Task<IEnumerable<ClassRoom>> GetClassRoomByName(string classRoomName);
    }
}
