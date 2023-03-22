using Domain.Entities;
using Domain.Entities.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations.System
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.LanguageId).IsRequired();
            builder.Property(x => x.AcademicYearId).IsRequired();
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.SubjectId).IsRequired();

            
        }
    }
}
