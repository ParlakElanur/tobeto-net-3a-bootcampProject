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
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey("Id");

            builder.Property(o => o.Id).HasColumnName("Id");
            builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(o=>o.Name).HasColumnName("Name");

            builder.HasMany(o => o.UserOperationClaims);
        }
    }
}
