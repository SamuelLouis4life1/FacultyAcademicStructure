using AcademicStructure.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AcademicStructure.Infrastructure.Persistence
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext applicationDbContext, ILogger<ApplicationContextSeed> logger)
        {
            if (!applicationDbContext.Students.Any() || 
                applicationDbContext.Teachers.Any() || 
                applicationDbContext.ClassRooms.Any())
            {
                applicationDbContext.Students.AddRange(GetPreconfiguredStudents());
                applicationDbContext.Teachers.AddRange(GetPreconfiguredTeachers());
                applicationDbContext.ClassRooms.AddRange(GetPreconfiguredClassRooms());
                await applicationDbContext.SaveChangesAsync();

                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationDbContext).Name);
            }
        }

        private static IEnumerable<Student> GetPreconfiguredStudents()
        {
            return new List<Student>
            {
                new Student() {FullName = "Samuel Sampeur Louis ", CPF = "158.587.654-26", Matricula = 4249891, Email = "samuel.louis@al.infnet.edu.br", Address = {CEP = "258294219", AddicionalAddress = "Rua Avenida", City = "Rio"}, PhoneNumber = 4926915451 }
            };
        }        
        
        private static IEnumerable<Teacher> GetPreconfiguredTeachers()
        {
            return new List<Teacher>
            {
                new Teacher() {FullName = "Rafael bento Cruz", CPF = "250.280.824-26", Matricula = 14515, Email = "rafaelbento@prof.infnet.edu.br", Address = {CEP = "258294219", AddicionalAddress = "Rua Avenida", City = "Rio"}, PhoneNumber = 49256915451 }
            };
        }     
        
        private static IEnumerable<ClassRoom> GetPreconfiguredClassRooms()
        {
            return new List<ClassRoom>
            {
                new ClassRoom() {ClassName = "Formatura" }
            };
        }

    }
}
