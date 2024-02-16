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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.UserName).HasColumnName("UserName");
            builder.Property(e => e.FirstName).HasColumnName("FirstName");
            builder.Property(e => e.LastName).HasColumnName("LastName");
            builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.Property(e => e.Password).HasColumnName("Password");
            builder.Property(e => e.Position).HasColumnName("Position");

        }
    }
}
