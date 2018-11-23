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
        [HttpPost] [ValidateAntiForgeryToken]//Anti Cross Site Request Forgeryf
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Generes = dbContext.Generes.ToList();//bug fix : while post back ,viewModel is a new object ,Geners not intialized
                return View("Create", viewModel);
            }

         var gig = new Gig() 
            {
                ArtistId = User.Identity.GetUserId(),//Get Currently logged User.
                DateTime = viewModel.GetDateTime(),//combine two fields to one filed: {data,time}=>datetime 
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