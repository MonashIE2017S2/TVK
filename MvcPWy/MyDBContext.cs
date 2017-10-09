/*
	Author: Roshan Krishnan Thirikkott
*/
using MvcPWy.Models;
using MvcPWy.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
/*
using TheSecondHomeAPI.Auth;
*/

namespace MvcPWy
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=DefaultConnection")
        {
        }
        //public dbContext() : base() { }
        //User
        public DbSet<UserSecret> UserSecret { get; set; }
        public DbSet<UserPersonal> UserPersonal { get; set; }
        // public DbSet<UserToken> UserToken { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<IdentifyQuestion> IdentifyQuestions { get; set; }
        public DbSet<Sfys> Sfys { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Suburb> Suburb { get; set; }
        public DbSet<ChildFirst> ChildFirst { get; set; }
        public DbSet<Support> Support { get; set; }
        public DbSet<ReEngage> ReEngage { get; set; }
    }
}