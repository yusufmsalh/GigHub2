using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Migrations;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class GigsController : Controller
    {
        private ApplicationDbContext dbContext;

        public GigsController()
        {
            dbContext = new ApplicationDbContext();

        }
        // GET: Gigs
      
        [HttpGet]
        public ActionResult Create()
        {
           GigFormViewModel gigsViewModel = new GigFormViewModel()
            {
                Generes = dbContext.Generes.ToList()
            };
            return View(gigsViewModel);
        }
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var artist = dbContext.Users.Single(u => u.Id == User.Identity.GetUserId());// application user object that can associated with gig
          var gig = new Gig()
          {
              Artist = artist,
              DateTime = DateTime.Parse(string.Format("{0} {1}" ,viewModel.Date,viewModel.Time)),

          }

            return View();
        }


    }
}