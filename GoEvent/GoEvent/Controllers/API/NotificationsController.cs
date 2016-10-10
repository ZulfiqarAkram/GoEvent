using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using GoEvent.Core.Dto;
using GoEvent.Core.Models;
using GoEvent.Persistence;

namespace GoEvent.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationsController()
        {
            _dbContext=new ApplicationDbContext();
        }

       
        public IEnumerable<NotificationDto> GetNewNotification()
        {
            string userId=User.Identity.GetUserId();
            var notification = _dbContext.UserNotifications
                .Where(u => u.UserId == userId && !u.IsRead)
                .Select(u => u.Notification)
                .Include(g => g.Event.Artist)
                .ToList();

            return notification.Select(Mapper.Map<Notification,NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notification= _dbContext.UserNotifications
                .Where(u => u.UserId == userId && !u.IsRead)
                .ToList();
        
            notification.ForEach(n=>n.Read());

            _dbContext.SaveChanges();

            return  Ok();
        }


    }
}
