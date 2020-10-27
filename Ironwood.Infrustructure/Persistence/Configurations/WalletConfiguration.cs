using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");
            //Make Primary Key
            builder.HasKey("ID");
            //Make Wallet Address Unique
            builder.HasIndex(a => a.Address)
                .IsUnique();
            //Relationship
            builder.HasOne(a => a.User)
                .WithOne(a => a.Wallet)
                .HasForeignKey<Wallet>("ID");

        }
    }
}
