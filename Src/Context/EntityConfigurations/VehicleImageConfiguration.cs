using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class VehicleImageConfiguration : IEntityTypeConfiguration<VehicleImage>
    {
        public void Configure(EntityTypeBuilder<VehicleImage> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.Vehicle)
              .WithMany(f => f.VehicleImage)
              .HasForeignKey(x => x.VehicleId);
        }
    }
}
