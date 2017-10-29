using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MusicLovers.Core.Contracts.Repositories.Contracts;
using MusicLovers.Core.Models.Entities;
using MusicLovers.Persistence;

namespace MusicLovers.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Notification> GetNewNotifications(string userId)
        {
            return _context.UserNotificationSet
                .Where(u => u.UserId == userId && !u.IsRead)
                .Select(u => u.Notification)
                .Include(g => g.Gig.Artist)
                .ToList();
        }

        public List<UserNotification> GetNewUserNotifications(string userId)
        {
            return _context.UserNotificationSet
                .Where(u => u.UserId == userId && !u.IsRead)
                .ToList();
        }
    }
}