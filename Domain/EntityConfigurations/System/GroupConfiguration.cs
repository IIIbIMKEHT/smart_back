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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.TitleKz).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TitleRu).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TitleEn).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.DepartmentId).IsRequired();
        }
    }
}
