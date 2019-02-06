using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsApiController : ApiController
    {
        #region ctor
        private ApplicationDbContext dbContext;
        public GigsApiController()
        {
            dbContext = new ApplicationDbContext();

        }
        #endregion
        [HttpDelete]
        public IHttpActionResult CancelGig(int id)
        {
            var currentlyloggedUserId = User.Identity.GetUserId();
            var gig = dbContext.Gigs.
                SingleOrDefault(e => e.Id == id && e.ArtistId == currentlyloggedUserId);
            if (gig != null && gig.IsCancelled != true)
            {
                gig.IsCancelled = true;// use enum
                dbContext.SaveChanges();
                #region Creating A Cancel -Notification Object
                var notification = new Notification()
                {
                    // creating a  a cancelling notification 
                    Gig = gig,
                    DateTime = DateTime.Now,
                    Type = NotificationType.GigCancelled
                };
                #endregion
                #region Getting Those who will attend the Gig
                var thoseWhoAttendThisGig = dbContext.Attendences
                        .Where(a => a.GigId == gig.Id)
                         .Select(a => a.Attender).ToList();
                #endregion
                #region for each attender ,Send Him A notification
                foreach (var attendee in thoseWhoAttendThisGig)
                {//generating a  user-notification object 
                    //for each attender.
                    var userNotfication = new UserNotification()
                    {
                        User = attendee,
                        Notification = notification

                    };
                    dbContext.UserNotification.Add(userNotfication);
                } 
                    dbContext.SaveChanges();
                #endregion
            }
            else
            {
                return NotFound();
            }


            return Ok(); 
        }
    }
}
