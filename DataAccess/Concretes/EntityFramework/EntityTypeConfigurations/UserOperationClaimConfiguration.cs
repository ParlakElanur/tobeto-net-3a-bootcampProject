using Core.Utilities.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey("Id");

            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(u=>u.UserId).HasColumnName("UserId");
            builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");

            builder.HasOne(u => u.User);
            builder.HasOne(u => u.OperationClaim);
        }
    }
}
