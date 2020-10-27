﻿// <auto-generated />
using System;
using Ironwood.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ironwood.Infrastructure.Migrations
{
    [DbContext(typeof(IronwoodDbContext))]
    [Migration("20201027114624_InitialMig")]
    partial class InitialMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ironwood.Domain.Entities.LoginHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("LoggedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("RegionName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("UserLoginID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserLoginID");

                    b.ToTable("LoginHistories");
                });

            modelBuilder.Entity("Ironwood.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AccessRole")
                        .HasColumnType("tinyint");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(320)")
                        .HasMaxLength(320);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.HasIndex("UID")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AccessRole = (byte)1,
                            EmailAddress = "admin@auxiliaglobal.com",
                            FirstName = "Admin",
                            LastName = "App",
                            UID = new Guid("174f3731-c23a-48ed-948c-eda9a8f6a05e")
                        });
                });

            modelBuilder.Entity("Ironwood.Domain.Entities.UserLogin", b =>
                {
                    b.Property<int?>("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastChangedPassword")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(500)")
                        .HasMaxLength(500);

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserLogins");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Password = new byte[] { 0, 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 152, 156, 47, 115, 252, 177, 181, 237, 49, 172, 91, 121, 81, 188, 196, 100, 45, 157, 169, 124, 209, 176, 77, 87, 192, 4, 80, 245, 135, 176, 31, 123 },
                            Salt = new byte[] { 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 64, 35, 36 },
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Ironwood.Domain.Entities.Wallet", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<Guid>("Address")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Ironwood.Domain.Entities.WalletTransaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(20,8)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("TransactedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WalletID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("WalletID");

                    b.ToTable("WalletTransactions");
                });

            modelBuilder.Entity("Ironwood.Domain.Entities.LoginHistory", b =>
                {
                    b.HasOne("Ironwood.Domain.Entities.UserLogin", null)
                        .WithMany("LoginHistory")
                        .HasForeignKey("UserLoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ironwood.Domain.Entities.UserLogin", b =>
                {
                    b.HasOne("Ironwood.Domain.Entities.User", "User")
                        .WithOne("UserLogin")
                        .HasForeignKey("Ironwood.Domain.Entities.UserLogin", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ironwood.Domain.Entities.Wallet", b =>
                {
                    b.HasOne("Ironwood.Domain.Entities.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("Ironwood.Domain.Entities.Wallet", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ironwood.Domain.Entities.WalletTransaction", b =>
                {
                    b.HasOne("Ironwood.Domain.Entities.Wallet", "Wallet")
                        .WithMany("WalletTransactions")
                        .HasForeignKey("WalletID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
