using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class WalletTransactionConfiguration : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");
            //Make Primary Key
            builder.HasKey("ID");
            //Add Prop for the ForeignKey
            builder.Property<int>("WalletID");
           
            //Other Config
            builder.Property(a => a.Remarks)
                .HasMaxLength(255);
            builder.Property<Decimal>("Amount")
                .HasColumnType($"DECIMAL(20,8)");


            //Relationship
            builder.HasOne(a => a.Wallet)
               .WithMany(a => a.WalletTransactions)
               .HasForeignKey("WalletID");

           
        }
    }
}
