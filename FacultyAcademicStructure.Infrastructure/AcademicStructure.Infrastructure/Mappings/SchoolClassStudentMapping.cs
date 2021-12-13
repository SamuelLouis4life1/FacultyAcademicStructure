using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcademicStructure.Infrastructure.Mappings
{
    class SchoolClassStudentMapping : IEntityTypeConfiguration<SchoolClassStudent>
    {
        public void Configure(EntityTypeBuilder<SchoolClassStudent> builder)
        {
            builder.HasKey(p => new { 
            p.SchoolClassId, p.StudentId});

            builder.HasOne(p => p.SchoolClass)
                .WithMany(p => p.SchoolClassStudents)
               .HasForeignKey(p => p.SchoolClassId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(p => p.Student)
                .WithMany(p => p.SchoolClassStudents)
               .HasForeignKey(p => p.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
