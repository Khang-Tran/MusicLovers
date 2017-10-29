using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Core.Contracts.Repositories.Contracts
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewNotifications(string userId);
        List<UserNotification> GetNewUserNotifications(string userId);

    }
}