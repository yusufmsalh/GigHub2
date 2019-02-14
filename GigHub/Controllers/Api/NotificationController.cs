using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            var newNotificationList = dbContext.
            #region Getting New Notifications for Currently Logged User ,Eager load Gig,Artist to display them
          UserNotification
                        .Where(un => un.UserId == currentlyLoggedUserId && un.IsRead == false)
                        .Select(e => e.Notification)
                        .Include(n => n.Gig.Artist)
                        .ToList().Select(notification => new NotificationDto()
                        {
                            #region NotificationDto
                            Id = notification.Id,
                            DateTime = notification.DateTime,
                            Type = notification.Type,
                            OriginalDateTime = notification.OriginalDateTime,
                            OriginalVenue = notification.OriginalVenue,
                            #region GigDto
                            Gig = new GigDto()
                            {
                                Id = notification.Gig.Id,
                                DateTime = notification.Gig.DateTime,
                                GenereId = notification.Gig.GenereId,
                                IsCancelled = notification.Gig.IsCancelled,
                                Venue = notification.Gig.Venue,
                                #region UserDto
                                Artist = new UserDto()
                                {
                                    Id = notification.Gig.Artist.Id,
                                    Name = notification.Gig.Artist.Name
                                },
                                #endregion
                                #region GenereDto

                                GenereDto = new GenereDto()
                                {
                                    Id = notification.Gig.Genere.Id,
                                    Name = notification.Gig.Genere.Name
                                }
                                #endregion
                            }
                            #endregion
                            #endregion
                        }); 
            #endregion
            return newNotificationList;
        }
    }
}
