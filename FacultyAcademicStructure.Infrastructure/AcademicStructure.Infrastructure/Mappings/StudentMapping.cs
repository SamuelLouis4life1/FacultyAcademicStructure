using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcademicStructure.Infrastructure.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(p => p.Id);


            #region Relationships

            builder.HasMany(p => p.SchoolClassStudents)
                .WithOne(p => p.Student)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Person)
                .WithOne(p => p.Student)
                .HasForeignKey<Student>(p => p.Id);

            
            #endregion
        }
    }
}
