using GigHub.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genere> Generes { get; set; }
        public DbSet<Attendence> Attendences { get; set; }//Event of user attending a Party


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            //use dbModelBuilder to provide additional configuration 
            //here we use fluent api,that goes like
            //entity,directio 1 ,other direction ,cascade delete = false.
            //make sure to call base .on model creating  due to msdn overrides
            dbModelBuilder.Entity<Attendence>().
                HasRequired(a => a.Gig).WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(dbModelBuilder);
        }

    }

}