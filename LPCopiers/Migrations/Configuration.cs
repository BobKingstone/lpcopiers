namespace LPCopiers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<LPCopiers.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LPCopiers.MainContext context)
        {
            //WebSecurity.InitializeDatabaseConnection(
            //    "MainContext",
            //    "UserProfile",
            //    "UserId",
            //    "UserName", autoCreateTables: true);

            //if (!Roles.RoleExists("Admin"))
            //    Roles.CreateRole("Admin");

            //if (!WebSecurity.UserExists("admin"))
            //    WebSecurity.CreateUserAndAccount(
            //        "admin",
            //        "password");

            //if (!Roles.GetRolesForUser("admin").Contains("Admin"))
            //    Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });

        }
    }
}
