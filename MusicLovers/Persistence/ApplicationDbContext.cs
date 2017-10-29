using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicLovers.Core.Models;
using MusicLovers.Core.Models.Entities;
using MusicLovers.Persistence.EntityConfigurations;

namespace MusicLovers.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> GigSet { get; set; }
        public DbSet<Genre> GenreSet { get; set; }
        public DbSet<Attendance> AttendanceSet { get; set; }
        public DbSet<Following> FollowingSet { get; set; }
        public DbSet<Notification> NotificationSet { get; set; }
        public DbSet<UserNotification> UserNotificationSet { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GigConfigurations());
            modelBuilder.Configurations.Add(new AttendanceConfigurations());
            modelBuilder.Configurations.Add(new FollowingConfigurations());
            modelBuilder.Configurations.Add(new GenreConfigurations());
            modelBuilder.Configurations.Add(new NotificationConfigurations());
            modelBuilder.Configurations.Add(new UserNotificationConfigurations());
            modelBuilder.Configurations.Add(new UserConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}