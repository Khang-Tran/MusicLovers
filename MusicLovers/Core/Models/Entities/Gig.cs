using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MusicLovers.Core.Models.Entities
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }

        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public int GenreId { get; set; }
   
        public Genre Genre { get; set; }

        public bool IsCancel { get; private set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCancel = true;
            // Notification
            var notification = Notification.GigCanceled(this);

            // Get all attendees that registered that gig
            var attendees = Attendances.Select(a => a.Attendee);
            // Send notification for them
            foreach (var attendee in attendees)
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string venue, int genreId)
        {
            // Create a notification for updating current gig and originalDateTime and originalVenu
            var notification = Notification.GigUpdated(this, DateTime, Venue);
            // Set items to new values
            Venue = venue;
            DateTime = dateTime;
            GenreId = genreId;
            // Notify every attendees for new notification
            foreach (var attendee in Attendances.Select(g => g.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}