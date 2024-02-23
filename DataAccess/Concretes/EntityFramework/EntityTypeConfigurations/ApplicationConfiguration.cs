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
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Applications").HasKey("Id");

            builder.Property(a => a.Id).HasColumnName("Id");
            builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(a => a.ApplicantId).HasColumnName("ApplicantId");
            builder.Property(a => a.BootcampId).HasColumnName("BootcampId");
            builder.Property(a => a.ApplicationStateId).HasColumnName("ApplicationStateId");

            builder.HasOne(a => a.Applicant);
            builder.HasOne(a => a.Bootcamp);
            builder.HasOne(a => a.ApplicationState);
        }
    }
}
