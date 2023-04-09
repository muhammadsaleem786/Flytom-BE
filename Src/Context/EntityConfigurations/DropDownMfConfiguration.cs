using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class DropDownMfConfiguration : IEntityTypeConfiguration<sys_drop_down_mf>
    {
        public void Configure(EntityTypeBuilder<sys_drop_down_mf> builder)
        {
            builder.ConfigureBase();
        }
    }
}
