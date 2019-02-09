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
            if (gig != null && gig.IsCancelled != true)//avoid duplicate cancellation
            {
                gig.IsCancelled = true;// use enum
                dbContext.SaveChanges();//Refactor
                #region Here ,I simply want to broadcast a single message (cancel gig) to all assoicated users
                #region Creating A Cancel -Notification Object

                var notification = new Notification(gig, NotificationType.GigCancelled);
                #region How to refactor
                /*
         *Steps to refactor:
         * 1- create 2 ctor ,paramertrize with null ref exception to ensure required obj(gig).
         * 2- and a default one for EF
         * 3-set private setter for that object (gig)/ whatever passed in ctor ,to make it only set by ctor not by code.
         * 4- re write calling the class like new Notification(gig, NotificationType.GigCancelled);
         */

                #endregion               #endregion
                #region Getting Those who will attend the Gig
                var thoseWhoAttendThisGig = dbContext.Attendences
                        .Where(a => a.GigId == gig.Id)
                         .Select(a => a.Attender).ToList();
                #endregion
                #region for each attender ,Send Him A notification
                foreach (var attendee in thoseWhoAttendThisGig)
                {
                    //generating a  user-notification object 
                    //for each attender.

                    attendee.Notifiy(notification);
                    #region Pre Refatoring the above line
                    //  var userNotfication = new UserNotification()
                    //{
                    //    User = attendee,
                    //    Notification = notification
                    //    dbContext.UserNotification.Add(userNotfication);
                    //};
                    //1-move this  to a sperate method in the ApplicationUser Class
                    //2- Use: this --current object .
                    //3-Notification : passed as Parameter

                    /* Region : Replacing dbContext in the private Method
                    //4-dbContext : Add A Local Navigation Property to The Application User Class,
                    //add new object to Navigation property and EF will Add to DB (UserNotification.Add(userNotfication)).
                    //5-Intialize list in the ApplictionUser Ctor
                       End Region */
                    #endregion
                }
                dbContext.SaveChanges();
                #endregion
                #endregion
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
