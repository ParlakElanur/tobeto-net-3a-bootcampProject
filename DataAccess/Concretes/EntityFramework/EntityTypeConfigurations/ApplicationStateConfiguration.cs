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
    public class ApplicationStateConfiguration : IEntityTypeConfiguration<ApplicationState>
    {
        public void Configure(EntityTypeBuilder<ApplicationState> builder)
        {
            builder.ToTable("ApplicationStates").HasKey("Id");

            builder.Property(a => a.Id).HasColumnName("Id");
            builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(a => a.Name).HasColumnName("Name");

            builder.HasMany(a => a.Applications);
        }
    }
}
