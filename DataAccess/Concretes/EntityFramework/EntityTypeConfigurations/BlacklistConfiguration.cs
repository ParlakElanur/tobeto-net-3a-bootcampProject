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
    public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
    {
        public void Configure(EntityTypeBuilder<Blacklist> builder)
        {
            builder.ToTable("Blacklists").HasKey(b => b.Id);

            builder.Property(b=>b.Id).HasColumnName("id");
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(b => b.Reason).HasColumnName("Reason");
            builder.Property(b => b.Date).HasColumnName("Date");
            builder.Property(b => b.ApplicantId).HasColumnName("ApplicantId");

            builder.HasOne(b => b.Applicant);
        }
    }
}
