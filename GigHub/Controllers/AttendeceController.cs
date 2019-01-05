using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
   
    public class AttendeceController : ApiController
    {
        private ApplicationDbContext dbContext;

        public AttendeceController() 
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBodyAttribute] int gigId)
        {
            #region Avoid Duplicate Attendence

            //var attenderId = User.Identity.GetUserId();
            var attenderId = "50cbfce6-8cf3-4e17-a885-81375da81a43"; //for testing
            var isDuplicate = dbContext.Attendences.Any(a => a.AttenderId == attenderId && a.GigId == gigId);
            if (isDuplicate)
            {
                return BadRequest("You have already Attended This Gig");
            }

            #endregion
            var attendence = new Attendence()
            {
                GigId = gigId,
                AttenderId = User.Identity.GetUserId()
                //AttenderId = "52f143fb-381c-484c-af5e-ffcb562a51b7"
                //"50cbfce6-8cf3-4e17-a885-81375da81a43"

            };
            dbContext.Attendences.Add(attendence);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
