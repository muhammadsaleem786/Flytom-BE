using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class VehicleModelsConfiguration : IEntityTypeConfiguration<VehicleModels>
    {
        public void Configure(EntityTypeBuilder<VehicleModels> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.Makes)
              .WithMany(f => f.VehicleModels)
              .HasForeignKey(x => x.MakeId);

            builder.HasOne(x => x.Account)
              .WithMany(f => f.VehicleModels)
              .HasForeignKey(x => x.AccountId);
        }
    }
}
