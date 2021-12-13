using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcademicStructure.Infrastructure.Mappings
{
    public class SchoolSubjectMapping : IEntityTypeConfiguration<SchoolSubject>
    {
        public void Configure(EntityTypeBuilder<SchoolSubject> builder)
        {
            //builder.ToTable("SchoolClasses");

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.SchoolClasses)
                .WithOne(p => p.SchoolSubject)
                .HasForeignKey(p => p.SchoolSubjectId);
        }
    }
}
