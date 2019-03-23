using GigHub.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;

        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }
        public ActionResult Index(string query = null)
        {
            var currentlyLoggedUserId = User.Identity.GetUserId();
            var isAuthenticated = User.Identity.IsAuthenticated;//only show buttons to Authenticated users
            var upComingGigs = dbContext.Gigs.Include(g => g.Artist).Include(e => e.Genere)
                .Where(g => g.DateTime >= DateTime.MinValue && g.IsCancelled == false);        //get only future gigs
            if (!string.IsNullOrWhiteSpace(query))
            {
                upComingGigs = upComingGigs
                        .Where(a => a.Artist.Name.Contains(query) ||
                        a.Genere.Name.Contains(query) ||
                        a.Venue.Contains(query));
            }

                    var futureAttendecesForCurrentUser =
                    dbContext.Attendences.Where(a => a.AttenderId == currentlyLoggedUserId 
                    //   &&a.Gig.DateTime>DateTime.Now
                    ).ToList()
                    .ToLookup(attendence =>attendence.GigId) ;
                    //creats a look up table 
                    //to quickly look up an attendence by a gig id.

            GigsViewModel myUpCommingGigsViewModel = new GigsViewModel()
            {
                UpComingGigs = upComingGigs,
                IsAuthenticated = User.Identity.IsAuthenticated,
                SearchTerm = query,
                MyAttendences =  futureAttendecesForCurrentUser
            };
            //load future attendences for the currently logged user


            return View(myUpCommingGigsViewModel);
     
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     
        [HttpPost]
        public ActionResult Search(string SearchTerm)
        {
            return RedirectToAction("Index", "Home", new { query = SearchTerm });

        }

        

    }
}