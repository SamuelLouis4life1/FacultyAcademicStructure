using AcademicStructure.Domain.Common;
using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AcademicStructure.Infrastructure.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Address)
                .WithMany(p => p.People)
                .HasForeignKey(p => p.AddressId);

        }
    }
}
