using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using GigHub.DTO;
using GigHub.Migrations;

namespace GigHub.Controllers
{
   //[Authorize] add after testing
    public class AttendeceController : ApiController
    {
        private ApplicationDbContext dbContext;

        public AttendeceController() 
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttedenceDto dto)
        {
            #region Avoid Duplicate Attendence
            var attenderId = User.Identity.GetUserId();
            var passedparam2 = dto.passedParam2;// just playing with passed param
            var passedparam3 = dto.passedParam3;// just playing with passed param
            //var attenderId = "50cbfce6-8cf3-4e17-a885-81375da81a43"; //for testing
            var isDuplicate = dbContext.Attendences.Any(a => a.AttenderId == attenderId && a.GigId == dto.GigId);
            if (isDuplicate)
            {
                return BadRequest("You have already Attended This Gig");
            }

            #endregion
            var attendence = new Attendence()
            {
                GigId = dto.GigId,
                AttenderId = User.Identity.GetUserId()
                //AttenderId = "52f143fb-381c-484c-af5e-ffcb562a51b7"
                //"50cbfce6-8cf3-4e17-a885-81375da81a43"

            };
            dbContext.Attendences.Add(attendence);
            dbContext.SaveChanges();
            return Ok();
        }


        #region Demo Method
        //public IHttpActionResult AddGig(string x)
        //{
        //    var currentlyloggedUserId = User.Identity.GetUserId();
        //    var artist = dbContext.Users.SingleOrDefault(e => e.Id == currentlyloggedUserId);
        //    var gener = dbContext.Generes.SingleOrDefault(e => e.Id == 1);//passed from ddl
        //    Gig gig = new Gig()
        //    {
        //        ArtistId = currentlyloggedUserId,
        //        Artist = artist,
        //        Genere = gener
        //    };

        //    dbContext.Gigs.Add(gig);
        //    dbContext.SaveChanges();
        //    return Ok();
        //} 
        #endregion
    }
}
