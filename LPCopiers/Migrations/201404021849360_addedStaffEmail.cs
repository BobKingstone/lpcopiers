namespace LPCopiers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStaffEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "email", c => c.String());
            DropColumn("dbo.UserProfile", "engRef");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "engRef", c => c.String());
            DropColumn("dbo.UserProfile", "email");
        }
    }
}
