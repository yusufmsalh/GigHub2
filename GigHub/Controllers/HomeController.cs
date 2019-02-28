using GigHub.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.ViewModels;

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
            var isAuthenticated = User.Identity.IsAuthenticated;//only show buttons to Authenticated users
            var upComingGigs = dbContext.Gigs.Include(g => g.Artist).Include(e => e.Genere)
                .Where(g => g.DateTime >= DateTime.MinValue && g.IsCancelled == true);        //get only future gigs
            if (!string.IsNullOrWhiteSpace(query))
            {
                upComingGigs = upComingGigs
                        .Where(a => a.Artist.Name.Contains(query) ||
                        a.Genere.Name.Contains(query) ||
                        a.Venue.Contains(query));
            }
            GigsViewModel myUpCommingGigsViewModel = new GigsViewModel()
            {
                UpComingGigs = upComingGigs,
                IsAuthenticated = User.Identity.IsAuthenticated,
                SearchTerm = query
            };
            return View(myUpCommingGigsViewModel);
            //for each gig
            //get it's going state  
            //set it in the viewmodel
            //want set the isGoing property in Viewmodel 
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
        #region Search
        [HttpPost]
        public ActionResult Search(string SearchTerm)
        {
            return RedirectToAction("Index", "Home", new { query = SearchTerm });

        }

        #endregion

    }
}