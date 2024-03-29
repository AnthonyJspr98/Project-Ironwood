using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");

            //Make Primary Key
            builder.HasKey("ID");

            //Make UID Unique
            builder.HasIndex(a => a.UID)
            .IsUnique();

            builder.Property(a => a.Name)
            .HasMaxLength(50);
            
            
        }
    }
}