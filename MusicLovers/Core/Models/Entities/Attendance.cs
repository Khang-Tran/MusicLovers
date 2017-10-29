using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLovers.Core.Models.Entities
{
    public class Attendance
    {
        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }
        public int GigId { get; set; }
        public string AttendeeId { get; set; }

    }
}