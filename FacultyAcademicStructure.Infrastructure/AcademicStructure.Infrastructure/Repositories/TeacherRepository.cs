using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Domain.Entities;
using AcademicStructure.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AcademicStructure.Infrastructure.Repositories
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Teacher>> GetTeacherByName(string teacherName)
        {
            var teacherList = await _dbContext.DbTeachers
                                .Where(o => o.Person.Name == teacherName)
                                .ToListAsync();
            return teacherList;
        }
    }
}
