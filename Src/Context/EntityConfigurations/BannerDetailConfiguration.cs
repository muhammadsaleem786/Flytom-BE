using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class BannerDetailConfiguration : IEntityTypeConfiguration<BannerDetail>
    {
        public void Configure(EntityTypeBuilder<BannerDetail> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.ContentManagment)
              .WithMany(f => f.BannerDetail)
              .HasForeignKey(x => x.ContentManagmentId);
        }
    }
}
