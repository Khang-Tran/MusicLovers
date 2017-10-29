using System;
using MusicLovers.Core.Models;

namespace MusicLovers.Core.DTOs
{
    public class NotificationDto
    {
        public DateTime DateTime { get; private set; }
        public NotificationTypes NotificationType { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        public GigDto Gig { get; private set; }
    }
}