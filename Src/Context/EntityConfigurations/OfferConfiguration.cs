using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class OfferConfiguration : IEntityTypeConfiguration<MovingOffer>
    {
        public void Configure(EntityTypeBuilder<MovingOffer> builder)
        {
            builder.ConfigureBase();

            builder.HasOne(x => x.sys_drop_down_value)
          .WithMany(f => f.Offer)
          .HasForeignKey(x => x.TotalRoomId);

            builder.HasOne(x => x.sys_drop_down_value1)
             .WithMany(f => f.Offer1)
             .HasForeignKey(x => x.HouseTypeId);

            builder.HasOne(x => x.sys_drop_down_value2)
           .WithMany(f => f.Offer2)
           .HasForeignKey(x => x.FloorTypeId);

            builder.HasOne(x => x.sys_drop_down_value3)
       .WithMany(f => f.Offer3)
       .HasForeignKey(x => x.NewTotalRoomId);

            builder.HasOne(x => x.sys_drop_down_value4)
       .WithMany(f => f.Offer4)
       .HasForeignKey(x => x.NewHouseTypeId);

            builder.HasOne(x => x.sys_drop_down_value5)
      .WithMany(f => f.Offer5)
      .HasForeignKey(x => x.NewFloorTypeId);

        }
    }
}
