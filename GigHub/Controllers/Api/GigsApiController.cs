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
                SingleOrDefault(e => e.Id == id && e.ArtistId ==currentlyloggedUserId);
            if (gig != null)
            {
                gig.IsCancelled = true;// use enum
                dbContext.SaveChanges();

            }

            return Ok();
        }
    }
}
