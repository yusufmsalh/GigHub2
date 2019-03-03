using GigHub.Controllers;
using GigHub.Migrations;
using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDateValidation]
        public string Date { get; set; }

        [Required]
        [FutureTimeValidation]
        public string Time { get; set; }

        [Required(ErrorMessage = "Please Choose Genere")]
        public byte Genere { get; set; }
        public List<Genere> Generes { get; set; }//List of Geners from DB

        public DateTime GetDateTime()//Method not prop to avoid Exception caused by reflection in posting back in invalid model state
        {
            //return DateTime.Now;
            return DateTime.Parse(string.Format("{0} {1}", Date, Time)); // fix it later
        }
        public string Heading { get; set; }// use it to to change the heading of view ,as it's shared among multiple actions
        public string ActionToBeCalled
        {
            #region Getting Action Name in Run Time

            get
            {
                Expression<Func<GigsController, ActionResult>> UpdateMethod = (c => c.Edit(this));
                Expression<Func<GigsController, ActionResult>> CreateMethod = (c => c.Create(this));
                var actionToBeCalled = (Id != 0) ? UpdateMethod : CreateMethod;
                return (actionToBeCalled.Body as MethodCallExpression).Method.Name;
            }

            #region Above Part Explantion
            /* use the above part to get the method name at run time
             * to replace get { return (Id != 0) ? "Edit" : "Create"; }
             *and avoid magic(static) strings ,as if method name changed this
             * will break your code
             * Func : Pointer to a method
             * input of func : Gigs controller
             * return of func : action result from edit / create method  
             * this : a dummy value as edit method expects a viewmodel
             * func allows as to call that method (c => c.Edit(this))
             * but we don't want to call ,we want to save it as an expression
             * finally cast expression to method call expression
             *use MethodCallExpression to access method Name
             */
            //
            //// avoid magic strings as they are fixed and it method name changed ,
            /// your code will break down

            #endregion
            #endregion

        }
    }
}