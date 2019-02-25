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
        public ActionResult Index()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;//only show buttons to Authenticated users
            var upComingGigs = dbContext.Gigs
                .Include(g => g.Artist)
                .Include(e=>e.Genere)
                .Where(g => g.DateTime >= DateTime.Now && g.IsCancelled == true);//get only future gigs
            var gigsViewModel = new GigsViewModel()
            {
                UpComingGigs = upComingGigs,
                IsAuthenticated = isAuthenticated
            };
            return View(gigsViewModel);
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
    }
}