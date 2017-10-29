using System.Data.Entity.ModelConfiguration;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Persistence.EntityConfigurations
{
    public class GigConfigurations : EntityTypeConfiguration<Gig>
    {
        public GigConfigurations()
        {
            Property(g => g.ArtistId)
            .IsRequired();

            Property(g => g.Venue)
            .IsRequired()
            .HasMaxLength(255);

            Property(g => g.GenreId)
            .IsRequired();

            HasMany(g => g.Attendances)
                .WithRequired(a => a.Gig)
                .WillCascadeOnDelete(false);
        }
    }
}