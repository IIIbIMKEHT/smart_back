using Domain.Entities;
using Domain.Entities.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.IIN).IsUnique(true);
            builder.Property(p => p.IIN).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(255).IsRequired();
            
            builder.Property(p => p.Phone).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(p => p.UpdatedAt).ValueGeneratedOnUpdate();
            
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
