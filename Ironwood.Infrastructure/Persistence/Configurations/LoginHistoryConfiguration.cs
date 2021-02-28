using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class LoginHistoryConfiguration : IEntityTypeConfiguration<LoginHistory>
    {
        public void Configure(EntityTypeBuilder<LoginHistory> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");
            //Make Primary Key
            builder.HasKey("ID");

            builder.Property<int>("UserLoginID");

            builder.Property(a => a.IP)
                .HasMaxLength(20);

            builder.Property(a => a.LoggedOn)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(a => a.CountryCode)
                .HasMaxLength(2);

            builder.Property(a => a.RegionName)
                .HasMaxLength(128);

            builder.Property(a => a.CityName)
                .HasMaxLength(128);

            //Relationship
            builder.HasOne<UserLogin>()
              .WithMany(a => a.LoginHistory)
              .HasForeignKey("UserLoginID");
        }
    }
}
