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
    public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
    {
        public void Configure(EntityTypeBuilder<Bootcamp> builder)
        {
            builder.ToTable("Bootcamps").HasKey("Id");

            builder.Property(b=>b.Id).HasColumnName("Id");
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.InstructorId).HasColumnName("InstructorId");
            builder.Property(b => b.StartDate).HasColumnName("StartDate");
            builder.Property(b => b.EndDate).HasColumnName("EndDate");
            builder.Property(b => b.BootcampStateId).HasColumnName("BootcampStateId");

            builder.HasMany(b => b.Applications);
            builder.HasOne(b => b.Instructor);
            builder.HasOne(b => b.BootcampState);

        }
    }
}
