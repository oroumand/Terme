using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Terme.Core.Domain.Masters;
using Terme.Core.Domain.Masters.Entities;

namespace Terme.Infrastructures.Data.SqlServer.Masters.Configs
{
    public class MasterProductConfig : IEntityTypeConfiguration<MasterProduct>
    {
        public void Configure(EntityTypeBuilder<MasterProduct> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ShortDescription).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Description).IsRequired();
        }
    }
}
