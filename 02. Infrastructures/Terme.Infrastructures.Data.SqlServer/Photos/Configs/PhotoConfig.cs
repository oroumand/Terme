using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Terme.Core.Domain.Photos.Entities;

namespace Terme.Infrastructures.Data.SqlServer.Photos.Configs
{
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(c => c.Url).IsRequired().IsUnicode().HasMaxLength(1000);
        }
    }
}
