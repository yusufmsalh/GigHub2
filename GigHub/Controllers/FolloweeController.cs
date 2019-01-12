using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class FolloweeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public FolloweeController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: Followee
        public ActionResult Index()
        {//Who I am Following
            var currentlyloggedUserId = User.Identity.GetUserId();//follower wants to follow below artist
            var whoIAmFollowingList = dbContext.Following.
                Where(a => a.FollowerId == currentlyloggedUserId)
                .Select(a => a.Followee.Name).ToList();
                      return View(whoIAmFollowingList);
        
        }
    }
}