using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcademicStructure.Infrastructure.Mappings
{
    public class TeacherMapping : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            //builder.ToTable("Teachers");
            builder.HasKey(p => p.Id);


            #region Relationships

            builder.HasMany(p => p.SchoolClasses)
                .WithOne(p => p.Teacher)
                .HasForeignKey(p => p.TeacherId);

            builder.HasOne(p => p.Person)
                .WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(p => p.Id);
            #endregion
        }
    }
}
