using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class BootcampStateConfiguration : IEntityTypeConfiguration<BootcampState>
    {
        public void Configure(EntityTypeBuilder<BootcampState> builder)
        {
            builder.ToTable("BootcampStates").HasKey("Id");

            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(b => b.Name).HasColumnName("Name");

            builder.HasMany(b => b.Bootcamps);

        }
    }
}
