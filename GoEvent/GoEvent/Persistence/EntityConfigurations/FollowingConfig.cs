using GoEvent.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GoEvent.Persistence.EntityConfigurations
{
    public class FollowingConfig:EntityTypeConfiguration<Following>
    {
        public FollowingConfig()
        {
            HasKey(f => new {f.FollowerId, f.FolloweeId});
        }
    }
}