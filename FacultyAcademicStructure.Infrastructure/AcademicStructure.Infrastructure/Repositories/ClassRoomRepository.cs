using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Domain.Entities;
using AcademicStructure.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AcademicStructure.Infrastructure.Repositories
{
    public class ClassRoomRepository : RepositoryBase<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ClassRoom>> GetClassRoomByName(string classRoomName)
        {
            var classRoomList = await _dbContext.ClassRooms
                                .Where(o => o.ClassName == classRoomName)
                                .ToListAsync();
            return classRoomList;
        }
    }
}
