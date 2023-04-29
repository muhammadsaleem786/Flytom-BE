using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ConfigureBase();

            builder.HasOne(x => x.sys_drop_down_value)
          .WithMany(f => f.Offer)
          .HasForeignKey(x => x.FlexibleMovingDateId);

            builder.HasOne(x => x.sys_drop_down_value1)
             .WithMany(f => f.Offer1)
             .HasForeignKey(x => x.MovingLoadId);

            builder.HasOne(x => x.sys_drop_down_value2)
           .WithMany(f => f.Offer2)
           .HasForeignKey(x => x.NoOfPeopleId);

            builder.HasOne(x => x.sys_drop_down_value3)
       .WithMany(f => f.Offer3)
       .HasForeignKey(x => x.TotalRoomId);

            builder.HasOne(x => x.sys_drop_down_value4)
       .WithMany(f => f.Offer4)
       .HasForeignKey(x => x.HouseTypeId);

            builder.HasOne(x => x.sys_drop_down_value5)
     .WithMany(f => f.Offer5)
     .HasForeignKey(x => x.FloorTypeId).IsRequired(false);

            builder.HasOne(x => x.sys_drop_down_value6)
    .WithMany(f => f.Offer6)
    .HasForeignKey(x => x.NewTotalRoomId).IsRequired(false);

            builder.HasOne(x => x.sys_drop_down_value7)
    .WithMany(f => f.Offer7)
    .HasForeignKey(x => x.NewHouseTypeId).IsRequired(false);

            builder.HasOne(x => x.sys_drop_down_value8)
    .WithMany(f => f.Offer8)
    .HasForeignKey(x => x.NewFloorTypeId).IsRequired(false);
        }
    }
}
