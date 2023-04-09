using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class DropDownValueConfiguration : IEntityTypeConfiguration<sys_drop_down_value>
    {
        public void Configure(EntityTypeBuilder<sys_drop_down_value> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.sys_drop_down_mf)
              .WithMany(f => f.sys_drop_down_value)
              .HasForeignKey(x => x.DropDownID);
        }
    }
}
