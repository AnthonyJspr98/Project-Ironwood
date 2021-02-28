using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ironwood.Infrastructure.Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //Added ID prop(INT)
            builder.Property<int>("ID");

            //Make Primary Key
            builder.HasKey("ID");

            //Make UID Unique
            builder.HasIndex(a => a.UID)
            .IsUnique();

            builder.Property(a => a.Name)
            .HasMaxLength(20);
            
            builder.Property(a => a.Country)
            .HasMaxLength(20);
        }
    }
}