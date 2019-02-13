using System.Linq;
using System.Web.Http;
using GigHub.DTO;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
   
    public class FollowingController : ApiController
    {
        private readonly  ApplicationDbContext dbContext;

        public FollowingController()
        {
            dbContext= new ApplicationDbContext();
        }
        /// <summary>
        /// use passed parameter to create and insert new Follow Request
        /// validate unique request
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Follow(FollowingDTO dto)
        {
            var currentlyloggedUserId = User.Identity.GetUserId();//follower wants to follow below artist
            var followeeId = dto.FolloweeId;//leader ,to be followed

            #region Check if Repeated

            var isFound =
                dbContext.Following.Any(e => e.FollowerId == currentlyloggedUserId && e.FolloweeId == followeeId);
            if (isFound)
            {
                return BadRequest("You already Following this Artist");
            }

            #endregion
            var followingRelation = new FollowingRelation()
            {
                FollowerId  = currentlyloggedUserId,
                FolloweeId = followeeId

            };
            dbContext.Following.Add(followingRelation);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
