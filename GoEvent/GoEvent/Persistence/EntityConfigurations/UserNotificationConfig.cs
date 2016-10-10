using GoEvent.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GoEvent.Persistence.EntityConfigurations
{
    public class UserNotificationConfig:EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfig()
        {
            HasKey(un => new {un.UserId, un.NotificationId});

            HasRequired(u => u.User)
                .WithMany(u => u.UserNotifications)
                .WillCascadeOnDelete(false);
        }
    }
}