﻿using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GigHub.Migrations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace GigHub.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required][StringLength(100)]
        public string Name { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<FollowingRelation> Followers { get; set; }
        public ICollection<FollowingRelation> Followees { get; set; }
        public ICollection<UserNotification> UserNotification { get; set; }


        public ApplicationUser()
        {
            Followers = new Collection<FollowingRelation>(); // use must intialize list inside constructor
            Followees = new Collection<FollowingRelation>();
            UserNotification = new Collection<UserNotification>();
        }

        public void Notifiy(Notification notification)
        {
            #region Vital Error in UserNotification Class
            //User Notification Might Go to an Invalid State.
            //As Any one May Create an instance out of it
            // as both user and notification are required 
            //and that who may instate the usernotification 
            //may not follow this rule 
            #endregion
            var userNotfication = new UserNotification()
            {
                User = this,
                Notification = notification
            };
            UserNotification.Add(userNotfication);
        }
    }

}