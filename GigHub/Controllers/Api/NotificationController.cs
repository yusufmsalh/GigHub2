using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using GigHub.DTO;

namespace GigHub.Controllers.Api
{
    //api/Notification
    public class NotificationController : ApiController
    {
        private ApplicationDbContext dbContext;

        public NotificationController()
        {
            dbContext = new ApplicationDbContext();
        }

        //[Authorize]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            string currentlyLoggedUserId = "50cbfce6-8cf3-4e17-a885-81375da81a43";
            #region using AutoMapper

            #endregion

            var newNotificationList = dbContext.
                #region Getting New Notifications for Currently Logged User ,Eager load Gig,Artist to display them
                UserNotification
                .Where(un => un.UserId == currentlyLoggedUserId && un.IsRead == false)
                .Select(e => e.Notification)
                .Include(n => n.Gig.Artist)
               .ProjectTo<NotificationDto>()
                .ToList();


            //newNotificationList[0].Gig.Artist.Name;

            #endregion
            return newNotificationList;
        }
    }
}
