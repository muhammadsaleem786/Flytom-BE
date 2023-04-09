using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class MakesConfiguration : IEntityTypeConfiguration<Makes>
    {
        public void Configure(EntityTypeBuilder<Makes> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.Account)
                .WithMany(f => f.Makes)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
