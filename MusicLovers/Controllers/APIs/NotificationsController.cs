using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.DTOs;
using MusicLovers.Core.Models.Entities;
using MusicLovers.Persistence;

namespace MusicLovers.Controllers.APIs
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            // Find notifications in the database, based on userId.
            var notifications = _unitOfWork.Notifications.GetNewNotifications(userId);
            // AutoMapper
            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            // Get new and unread userNotifications
            var notifications = _unitOfWork.Notifications.GetNewUserNotifications(userId);
            // Mark all notification as read
            notifications.ForEach(n=>n.Read());

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
