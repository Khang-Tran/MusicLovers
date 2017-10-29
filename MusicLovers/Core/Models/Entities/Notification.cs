using System;
using System.ComponentModel.DataAnnotations;

namespace MusicLovers.Core.Models.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; private set; }
        public NotificationTypes NotificationType { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        public Gig Gig { get; private set; }
        // This one is for Entity framework
        private Notification()
        {

        }
        // Factory methods
        private Notification(Gig gig, NotificationTypes notificationType)
        {
            NotificationType = notificationType;
            Gig = gig ?? throw new ArgumentNullException("Gig is null");
            DateTime = DateTime.Now;
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationTypes.GigCreated);
        }
        public static Notification GigUpdated(Gig newGig, DateTime originalDateTime, string originalVenue)
        {
            return new Notification(newGig, NotificationTypes.GigUpdated)
            {
                OriginalDateTime = originalDateTime,
                OriginalVenue = originalVenue
            };
        }

        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationTypes.GigCanceled);
        }
    }
}