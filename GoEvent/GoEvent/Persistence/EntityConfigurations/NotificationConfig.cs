using GoEvent.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GoEvent.Persistence.EntityConfigurations
{
    public class NotificationConfig:EntityTypeConfiguration<Notification>
    {
        public NotificationConfig()
        {
            HasRequired(n => n.Event);
        }
    }
}