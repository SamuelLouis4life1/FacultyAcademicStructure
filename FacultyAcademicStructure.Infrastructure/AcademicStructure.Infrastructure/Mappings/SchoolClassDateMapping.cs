using AcademicStructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicStructure.Infrastructure.Mappings
{
    public class SchoolClassDateMapping : IEntityTypeConfiguration<SchoolClassDate>
    {
        public void Configure(EntityTypeBuilder<SchoolClassDate> builder)
        {
            builder.ToTable("SchoolClassDates");

            builder.HasKey(p => p.Id);

        }
    }
}
