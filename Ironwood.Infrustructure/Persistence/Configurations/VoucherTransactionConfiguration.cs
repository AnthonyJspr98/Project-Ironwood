using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class VoucherTransactionConfiguration : IEntityTypeConfiguration<VoucherTransaction>
    {
        public void Configure(EntityTypeBuilder<VoucherTransaction> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");
            //Make Primary Key
            builder.HasKey("ID");
            //Add Prop for the ForeignKey
            builder.Property<int>("VoucherID");
            //Add Prop for the ForeignKey
            builder.Property<int>("WalletID");
          

            //Relationship to Wallet
            builder.HasOne(a => a.Wallet)
               .WithMany(a => a.VoucherTransactions)
               .HasForeignKey("WalletID");

            //Relationship to Voucher
            builder.HasOne(a => a.Voucher)
                .WithMany(a => a.VoucherTransactions)
                .HasForeignKey("VoucherID");
                
        }
    }
}
