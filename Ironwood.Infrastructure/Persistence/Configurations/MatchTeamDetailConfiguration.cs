using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class MatchTeamDetailConfiguration : IEntityTypeConfiguration<MatchTeamDetail>
    {
        public void Configure(EntityTypeBuilder<MatchTeamDetail> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");

            //Make Primary Key
            builder.HasKey("ID");

            //Make UID Unique
            builder.HasIndex(a => a.UID)
            .IsUnique();

            //Add Prop for the ForeignKey
            builder.Property<int>("MatchID");
            builder.Property<int>("TeamID");


            //Relationship
            builder.HasOne(a => a.Match)
            .WithMany(a => a.MatchTeamDetails)
            .HasForeignKey("MatchID");
            
            builder.HasOne(a => a.Team)
            .WithMany(a => a.MatchTeamDetails)
            .HasForeignKey("TeamID");

        }
    }
}