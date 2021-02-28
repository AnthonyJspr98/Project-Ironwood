using System;
using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");

            //Make Primary Key
            builder.HasKey("ID");

            //Make UID Unique
            builder.HasIndex(a => a.UID)
            .IsUnique();

            //Decimal Property
            builder.Property<Decimal>("Amount")
            .HasColumnType($"DECIMAL(20,8)");

            //Make ForeignKey Prop(INt)
            builder.Property<int>("MatchID");
            builder.Property<int>("TeamID");
            builder.Property<int>("WalletID");

            //Relationship
            builder.HasOne(a => a.Match)
            .WithMany(a => a.Bets)
            .HasForeignKey("MatchID");

            builder.HasOne(a => a.Team)
            .WithMany(a => a.Bets)
            .HasForeignKey("TeamID");

            builder.HasOne(a => a.Wallet)
            .WithMany(a => a.Bets)
            .HasForeignKey("WalletID");

        }
    }
}