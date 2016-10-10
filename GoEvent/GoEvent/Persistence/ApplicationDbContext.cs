using GoEvent.Core.Models;
using GoEvent.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GoEvent.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ApplicationUserConfig());
            modelBuilder.Configurations.Add(new AttendanceConfig());
            modelBuilder.Configurations.Add(new FollowingConfig());
            modelBuilder.Configurations.Add(new GenreConfig());
            modelBuilder.Configurations.Add(new EventConfig());
            modelBuilder.Configurations.Add(new NotificationConfig());
            modelBuilder.Configurations.Add(new UserNotificationConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}