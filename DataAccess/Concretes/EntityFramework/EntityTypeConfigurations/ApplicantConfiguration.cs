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
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("Applicants").HasKey(i => i.Id);

            builder.Property(a => a.Id).HasColumnName("Id");
            builder.Property(a => a.InstructorId).HasColumnName("InstructorId");
            builder.Property(a => a.UserName).HasColumnName("UserName");
            builder.Property(a => a.FirstName).HasColumnName("FirstName");
            builder.Property(a => a.LastName).HasColumnName("LastName");
            builder.Property(a => a.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(a => a.Email).HasColumnName("Email");
            builder.Property(a => a.Password).HasColumnName("Password");
            builder.Property(a => a.About).HasColumnName("About");

            builder.HasOne(a => a.Instructor);

        }
    }
}
