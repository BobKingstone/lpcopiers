namespace LPCopiers.Migrations
{
    using LPCopiers.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    /// <summary>
    /// seeds database on each migration or database update, ensuring records are maintained
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<LPCopiers.UsersContext>
    {
        
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LPCopiers.UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "MainContext",
                "UserProfile",
                "UserId",
                "UserName",
                autoCreateTables: true);

            if (!Roles.RoleExists("Admin"))
                Roles.CreateRole("Admin");

            if (!Roles.RoleExists("Engineer"))
                Roles.CreateRole("Engineer");

            if (!WebSecurity.UserExists("admin"))
                WebSecurity.CreateUserAndAccount(
                    "admin",
                    "password");

            if (!Roles.GetRolesForUser("admin").Contains("Admin"))
                Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });

            if (!WebSecurity.UserExists("Eng001"))
                WebSecurity.CreateUserAndAccount(
                    "Eng001",
                    "password");

            if (!Roles.GetRolesForUser("Eng001").Contains("Engineer"))
                Roles.AddUsersToRoles(new[] { "Eng001" }, new[] { "Engineer" });

            if (!WebSecurity.UserExists("Eng002"))
                WebSecurity.CreateUserAndAccount(
                    "Eng002",
                    "password");

            if (!Roles.GetRolesForUser("Eng002").Contains("Engineer"))
                Roles.AddUsersToRoles(new[] { "Eng002" }, new[] { "Engineer" });

            var userprofile = new List<UserProfile>
            {
                new UserProfile { UserName="Eng001", email="robert.kingstone@gmail.com", surname="Bloggs", forename="Fred", area="Wrexham", contact="234433"},
                new UserProfile { UserName="Eng002", email="robert.kingstone@gmail.com",surname="Jones", forename="John", area="Liverpool", contact="3243245"}
            };

            userprofile.ForEach(s => context.UserProfiles.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();

            var equipment = new List<Equipment>
            {
                new Equipment { EngRef="Eng001", serialNo="434554t345", Make="HP", Model="Z123", Company="Glyndwr Uni", Contact="Mr Thomas", Location="Office C101"},
                new Equipment { EngRef="Eng002", serialNo="434534t345", Make="Dell", Model="DS234", Company="NatWest", Contact="Mre White", Location="Room 23"},
                new Equipment { EngRef="Eng001", serialNo="334445422", Make="Dell", Model="DS23", Company="Wrexham Gov", Contact="Mr Green", Location="Post Room"}
            };

            equipment.ForEach(s => context.Equipments.AddOrUpdate(e => e.serialNo, s));
            context.SaveChanges();

        }
    }
}
