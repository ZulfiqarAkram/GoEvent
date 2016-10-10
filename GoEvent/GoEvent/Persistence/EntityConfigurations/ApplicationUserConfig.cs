using GoEvent.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GoEvent.Persistence.EntityConfigurations
{
    public class ApplicationUserConfig:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(u=>u.Followers)
                .WithRequired(f=>f.Followee)
                .WillCascadeOnDelete(false);
            
            HasMany(u=>u.Followees)
                .WithRequired(f=>f.Follower)
                .WillCascadeOnDelete(false);
        }
    }
}