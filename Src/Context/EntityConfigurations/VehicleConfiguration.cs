using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.Account)
              .WithMany(f => f.Vehicle)
              .HasForeignKey(x => x.AccountId);

            builder.HasOne(x => x.sys_drop_down_value)
             .WithMany(f => f.Vehicle)
             .HasForeignKey(x => x.FuelTypeId);
            builder.HasOne(x => x.sys_drop_down_value1)
             .WithMany(f => f.Vehicle1)
             .HasForeignKey(x => x.DriveWheelType);

            builder.HasOne(x => x.sys_drop_down_value2)
           .WithMany(f => f.Vehicle2)
           .HasForeignKey(x => x.SteeringTypeId);

            builder.HasOne(x => x.sys_drop_down_value3)
       .WithMany(f => f.Vehicle3)
       .HasForeignKey(x => x.LicenceType);

            builder.HasOne(x => x.sys_drop_down_value4)
       .WithMany(f => f.Vehicle4)
       .HasForeignKey(x => x.NoOfSeatId);

            builder.HasOne(x => x.sys_drop_down_value5)
     .WithMany(f => f.Vehicle5)
     .HasForeignKey(x => x.SequreFeetId).IsRequired(false);


            builder.HasOne(x => x.Category)
         .WithMany(f => f.Vehicle)
         .HasForeignKey(x => x.CategoryId);

        }
    }
}
