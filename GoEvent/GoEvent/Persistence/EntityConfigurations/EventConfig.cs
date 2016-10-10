using GoEvent.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GoEvent.Persistence.EntityConfigurations
{
    public class EventConfig : EntityTypeConfiguration<Event>
    {
        public EventConfig()
        {

            Property(g => g.ArtistId)
                .IsRequired();

            Property(g => g.GenreId)
                .IsRequired();

            Property(g => g.Venue)
                .IsRequired()
                .HasMaxLength(255);


            HasMany(g => g.Attendances)
                .WithRequired(g => g.Event)
                .WillCascadeOnDelete(false);


        }
    }
}