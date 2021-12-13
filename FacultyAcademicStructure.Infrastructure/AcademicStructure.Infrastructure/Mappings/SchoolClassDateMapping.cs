using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcademicStructure.Infrastructure.Mappings
{
    public class SchoolClassDateMapping : IEntityTypeConfiguration<SchoolClassDate>
    {
        public void Configure(EntityTypeBuilder<SchoolClassDate> builder)
        {
            //builder.ToTable("SchoolClassDates");
            builder.HasKey(p => p.Id);


            #region Relationships
            builder.HasOne(p => p.SchoolClass)
                .WithMany(p => p.SchoolClassDates)
                .HasForeignKey(p => p.SchoolClassId);
            #endregion

        }
    }
}
