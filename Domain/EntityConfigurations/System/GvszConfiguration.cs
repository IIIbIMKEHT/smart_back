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
    public class GvszConfiguration : IEntityTypeConfiguration<Gvsz>
    {
        public void Configure(EntityTypeBuilder<Gvsz> builder)
        {
            builder.Property(x => x.WeekId).IsRequired();
            builder.Property(x => x.ExerciseId).IsRequired();
            builder.Property(x => x.SubjectId).IsRequired();
            builder.Property(x => x.GroupId).IsRequired();
        }
    }
}
