using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class VehiclePartConfiguration : IEntityTypeConfiguration<VehiclePart>
    {
        public void Configure(EntityTypeBuilder<VehiclePart> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.Vehicle)
              .WithMany(f => f.VehiclePart)
              .HasForeignKey(x => x.VehicleId);

            builder.HasOne(x => x.sys_drop_down_value)
             .WithMany(f => f.VehiclePart)
             .HasForeignKey(x => x.DropDownId);
        }
    }
}
