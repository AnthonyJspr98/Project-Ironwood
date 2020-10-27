using Ironwood.Domain.Entities;
using Ironwood.Enums;
using Ironwood.Infrastructure.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");
            //Make Primary Key
            builder.HasKey("ID");

            //Make Prop Unique
            builder.HasIndex(a => a.UID)
              .IsUnique();
            builder.HasIndex(a => a.EmailAddress)
                .IsUnique();

            //Other Config
            builder.Property(a => a.EmailAddress)
               .HasMaxLength(320)
               .IsRequired();

            builder.Property(a => a.Gender)
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.Property(a => a.FirstName)
                .HasMaxLength(100);
                
            builder.Property(a => a.MiddleName)
                .HasMaxLength(100);

            builder.Property(a => a.LastName)
                .HasMaxLength(100);
                 

            builder.Property(a => a.BirthDate)
                .HasColumnType("DATE");

            builder.HasData(new
            {
                ID = 1,
                UID = Guid.NewGuid(),
                FirstName = "Admin",
                LastName = "App",
                EmailAddress = "admin@auxiliaglobal.com",
                AccessRole = AccessRole.Admin
            });


        }
    }
}
