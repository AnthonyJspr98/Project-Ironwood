using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");

            //Make Primary Key
            builder.HasKey("ID");

            //Make UID Unique
            builder.HasIndex(a => a.UID)
              .IsUnique();

            //Add Prop for the ForeignKey
            builder.Property<int>("TournamentID");         

            //Relationship
            builder.HasOne(a => a.Tournament)
                .WithMany(a => a.Matches)
                .HasForeignKey("TournamentID");
            
           
            
        }
    }
}