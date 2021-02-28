using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            //Make Username Unique
            builder.HasIndex(e => e.Username).IsUnique();

            //Other Config
            builder.Property(p => p.Username).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Salt).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(500).IsRequired();

            builder.Property(a => a.LastChangedPassword)
                .HasDefaultValueSql("GETUTCDATE()");

            //Relationship
            builder.HasOne(a => a.User)
                .WithOne(a => a.UserLogin)
                .HasForeignKey<UserLogin>("ID");


            byte[] _salt = Encoding.ASCII.GetBytes("ADMIN-SALT-1234!@#$");
            string _passb64 = "AEFETUlOLVNBTFQtMTIzNCGYnC9z/LG17TGsW3lRvMRkLZ2pfNGwTVfABFD1h7Afew==";
            string _pass = "admin";

            builder.HasData(new
            {
                ID = 1,
                Username = "admin",
                IsTemporary = true,
                TemporaryPassword = _pass,
                Salt = _salt,
                Password = Convert.FromBase64String(_passb64)
            });
        }
    }
}
