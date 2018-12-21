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
            var attendence = new Attendence()
            {
                GigId = gigId,
                AttenderId = "50cbfce6-8cf3-4e17-a885-81375da81a43"
                    //User.Identity.GetUserId()
            };
            dbContext.Attendences.Add(attendence);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
