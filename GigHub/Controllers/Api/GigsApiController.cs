using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

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
            #region Eager load the part and those who will attend it
            var gig = dbContext.Gigs.Include(e => e.Attendence.Select(a => a.Attender)).
            SingleOrDefault(e => e.Id == id && e.ArtistId == currentlyloggedUserId);
            #endregion
            if (gig != null && gig.IsCancelled != true)//avoid duplicate cancellation
            {
                gig.CancelGig();
                dbContext.SaveChanges();

            }
            else
            {
                return NotFound();
            }


            return Ok();
        }


    }
}
