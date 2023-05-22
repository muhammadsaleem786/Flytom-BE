using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.sys_drop_down_value)
         .WithMany(f => f.ContactUs)
         .HasForeignKey(x => x.EnquiryTypeId);

            //  builder.HasOne(x => x.sys_drop_down_value)
            //.WithMany(f => f.Offer)
            //.HasForeignKey(x => x.TotalRoomId);



        }
    }
}
