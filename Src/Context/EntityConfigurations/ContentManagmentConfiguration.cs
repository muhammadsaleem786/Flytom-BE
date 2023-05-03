using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class ContentManagmentConfiguration : IEntityTypeConfiguration<ContentManagment>
    {
        public void Configure(EntityTypeBuilder<ContentManagment> builder)
        {
            builder.ConfigureBase();          

            builder.HasOne(x => x.sys_drop_down_value)
             .WithMany(f => f.ContentManagment)
             .HasForeignKey(x => x.ContentTypeId);
        }
    }
}
