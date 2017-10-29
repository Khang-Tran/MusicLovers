using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLovers.Core.Models.Entities
{
    public class UserNotification
    {
        public string UserId { get; private set; }
        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }
        public bool IsRead { get; private set; }
        // This one is Entity Framework
        private UserNotification()
        {

        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            User = user ?? throw new ArgumentNullException("User is null");
            Notification = notification ?? throw new ArgumentNullException("Notification is null");
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}