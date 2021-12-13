using AcademicStructure.Domain.Common;
using AcademicStructure.Domain.Entities;
using AcademicStructure.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> DbStudents { get; set; }
        public DbSet<Teacher> DbTeachers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<SchoolClassDate> SchoolClassDates { get; set; }
        public DbSet<SchoolSubject> SchoolSubjects { get; set; }
        public DbSet<SchoolClassStudent> SchoolClassStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new PersonMapping());
            modelBuilder.ApplyConfiguration(new SchoolClassDateMapping());
            modelBuilder.ApplyConfiguration(new SchoolClassMapping());
            modelBuilder.ApplyConfiguration(new SchoolSubjectMapping());
            modelBuilder.ApplyConfiguration(new StudentMapping());
            modelBuilder.ApplyConfiguration(new TeacherMapping());
            modelBuilder.ApplyConfiguration(new SchoolClassStudentMapping());
        }



        

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedDate = DateTime.Now;
                        //entry.Entity.CreatedBy = "Sampeur";
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedDate = DateTime.Now;
                        //entry.Entity.LastModifiedBy = "Sampeur";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
