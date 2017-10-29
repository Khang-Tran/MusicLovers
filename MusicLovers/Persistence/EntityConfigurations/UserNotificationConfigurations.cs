using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Persistence.EntityConfigurations
{
    public class UserNotificationConfigurations:EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfigurations()
        {
            HasKey(g => new {g.UserId, g.NotificationId});
            HasKey(un => new { un.UserId, un.NotificationId });

            HasRequired(n => n.User)
                .WithMany(u => u.UserNotifications)
                .WillCascadeOnDelete(false);
        }
    }
}