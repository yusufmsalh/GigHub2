using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Migrations;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

//Gig means party
//venue means the place of party ie :concert
// gener : means type of music
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
            var gig = new Gig() 
            {
                ArtistId = User.Identity.GetUserId(),//Get Currently logged User.
                DateTime = viewModel.DateTime,
                GenereId = viewModel.Genere, // type of music selected by user 
                Venue = viewModel.Venue //the place selecte by user
            };
            dbContext.Gigs.Add(gig);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
            //return View();
        }


    }
}