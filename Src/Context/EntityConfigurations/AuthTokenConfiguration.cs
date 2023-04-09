﻿using Context.EntityConfigurations.Extension;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.EntityConfigurations
{
    internal class AuthTokenConfiguration : IEntityTypeConfiguration<AuthToken>
    {
        public void Configure(EntityTypeBuilder<AuthToken> builder)
        {
            builder.ConfigureBase();
            builder.HasOne(x => x.Account)
               .WithMany(f => f.AuthTokens)
               .HasForeignKey(x => x.AccountId);

        }
    }
}
