using AcademicStructure.Domain.Common;
using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Infrastructure.Persistence
{
    public class ApplicationDataBContext : DbContext
    {
        public ApplicationDataBContext(DbContextOptions<ApplicationDataBContext> options) : base(options)
        {
        }

        public DbSet<Student> DbStudents { get; set; }
        public DbSet<Teacher> DbTeachers { get; set; }
        public DbSet<ClassRoom> DbClassRooms { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Sampeur";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Sampeur";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
