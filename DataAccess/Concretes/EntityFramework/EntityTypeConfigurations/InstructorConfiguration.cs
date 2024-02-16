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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("Id");
            builder.Property(i => i.UserName).HasColumnName("UserName");
            builder.Property(i => i.FirstName).HasColumnName("FirstName");
            builder.Property(i => i.LastName).HasColumnName("LastName");
            builder.Property(i => i.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(i => i.Email).HasColumnName("Email");
            builder.Property(i => i.Password).HasColumnName("Password");
            builder.Property(i => i.CompanyName).HasColumnName("CompanyName");

            builder.HasMany(i => i.Applicants);
        }
    }
}
