using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");
            //Make Primary Key
            builder.HasKey("ID");
           
            //Make Prop Unique
            builder.HasIndex(a => a.UID)
              .IsUnique();
            //Make Voucher Code Unique
            builder.HasIndex(a => a.Code)
                .IsUnique();

            builder.Property<Decimal>("Value")
               .HasColumnType($"DECIMAL(20,8)");



        }
    }
}
