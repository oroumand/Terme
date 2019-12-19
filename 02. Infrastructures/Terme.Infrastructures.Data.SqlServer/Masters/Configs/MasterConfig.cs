using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters;
using Terme.Core.Domain.Masters.Entities;

namespace Terme.Infrastructures.Data.SqlServer.Masters
{
    public class MasterConfig : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.ShortDescription).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.HasOne(c => c.Photo).WithOne().HasForeignKey("Photo","PhotoId");
        }
    }
}
