using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Migrations;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

//Gig means party
//venue means the place of party ie :concert
// gener : means type of music
namespace GigHub.Controllers
{
    [Authorize]
    public class GigsController : Controller
    {
        #region ctor
        private ApplicationDbContext dbContext;
        public GigsController()
        {
            dbContext = new ApplicationDbContext();

        }
        #endregion
        #region ViewGigs
        [HttpGet]
        public ActionResult ViewMyGigs()
        {
            var userID = User.Identity.GetUserId();
            var myGigs = dbContext.Attendences.Where(e => e.AttenderId == userID )
                .Select(a => a.Gig)
                .ToList();

            return View(myGigs);

        }
        public ActionResult ViewMyUpCommingGigs()
        {
            var userID = User.Identity.GetUserId();
            var myUpcommmingGigs = dbContext.Gigs.
                Where(e => e.ArtistId == userID && e.DateTime > DateTime.MinValue && e.IsCancelled ==true)//fix date later
                .Include(yusuf => yusuf.Genere)
                .ToList();
            return View(myUpcommmingGigs);

        }

        #endregion
        #region Create
        [HttpGet]
        public ActionResult Create()
        {

            GigFormViewModel gigsViewModel = new GigFormViewModel()
            {
                Generes = dbContext.Generes.ToList(),
                Heading = "Create New Gig"
            };
            return View("GigForm.cshtml", gigsViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]//Anti Cross Site Request Forgeryf
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)//invalid model
            {
                viewModel.Generes = dbContext.Generes.ToList();//bug fix : while post back ,viewModel is a new object ,Geners not intialized

                return View("Create", viewModel);
            }

            var gig = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),//Get Currently logged User.

                DateTime = viewModel.GetDateTime(),//combine two fields to one filed: {data,time}=>datetime 
                GenereId = viewModel.Genere, // type of music selected by user 
                Venue = viewModel.Venue //the place selected by user
            };
            dbContext.Gigs.Add(gig);
            dbContext.SaveChanges();
            return RedirectToAction("ViewMyUpCommingGigs", "Home");
            //return View();
        }


        #endregion
        #region Edit
        /// <summary>
        /// Edit Gig -Get to return Gig Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {

            // step 1 : get gig with ID passed
            var currentlyLoggedUserId = User.Identity.GetUserId();
            var myGig = dbContext.Gigs.Where(hema => hema.Id == id && hema.ArtistId == currentlyLoggedUserId).SingleOrDefault();//force immediate execution
            List<Genere> generes = dbContext.Generes.ToList();
            GigFormViewModel gigFormViewModel = null;
            if (myGig != null)
            {
                gigFormViewModel = new GigFormViewModel()
                {
                    Date = myGig.DateTime.ToShortDateString(),
                    Time = myGig.DateTime.ToShortTimeString(),
                    Venue = myGig.Venue,
                    Generes = generes,
                    Genere = myGig.GenereId,
                    Heading = "Editing Gig",
                    Id = myGig.Id

                };
            }
            return View("GigForm", gigFormViewModel);
        }

        [HttpPost]
        public ActionResult Edit(GigFormViewModel gigFormViewModel)
        {
            //mapping vm to db obj and save in DB
            Gig gig = null;
            var currentlyloggedUserId = User.Identity.GetUserId();
            gig = dbContext.Gigs.Where(e => e.Id == gigFormViewModel.Id && e.ArtistId == currentlyloggedUserId).SingleOrDefault();
            if (gigFormViewModel != null)
            {
                gig.Venue = gigFormViewModel.Venue;
                gig.DateTime = gigFormViewModel.GetDateTime();
                gig.GenereId = gigFormViewModel.Genere;
                //dbContext.Gigs.Attach(gig);
                dbContext.SaveChanges();
            }
            List<Gig> gigsLsList = dbContext.Gigs.ToList();
            return RedirectToAction("ViewMyUpCommingGigs", "Gigs");
        }

        #endregion


    }
}