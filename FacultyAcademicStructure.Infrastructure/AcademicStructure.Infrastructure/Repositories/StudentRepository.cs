using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Domain.Entities;
using AcademicStructure.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AcademicStructure.Infrastructure.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Student>> GetStudentsByName(string studentName)
        {
            var studentList = await _dbContext.DbStudents
                                .Where(o => o.FullName == studentName)
                                .ToListAsync();
            return studentList;
        }
    }
}
