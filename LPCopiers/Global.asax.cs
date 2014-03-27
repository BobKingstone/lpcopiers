﻿using LPCopiers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LPCopiers
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }

    //public class MainContext : DbContext
    //{
    //    public MainContext()
    //    {
    //        Database.SetInitializer<MainContext>(new DropCreateDatabaseIfModelChanges<MainContext>());

    //    }

    //    public DbSet<UserProfile> UserProfiles { get; set; }
    //    public DbSet<Equipment> Equipment { get; set; }
    //}
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("MainContext")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
    }
}