using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcademicStructure.Infrastructure.Mappings 
{
    public class SchoolClassMapping : IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            //builder.ToTable("SchoolClasses");

            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.SchoolClassStudents)
                .WithOne(p => p.SchoolClass)
                .HasForeignKey(p => p.SchoolClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Teacher)
                .WithMany(p => p.SchoolClasses)
                .HasForeignKey(p => p.TeacherId);

            builder.HasOne(p => p.SchoolSubject)
                .WithMany(p => p.SchoolClasses)
                .HasForeignKey(p => p.SchoolSubjectId);

            builder.HasMany(p => p.SchoolClassDates)
                .WithOne(p => p.SchoolClass)
                .HasForeignKey(p => p.SchoolClassId);

        }
    }
}
