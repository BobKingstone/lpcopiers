namespace LPCopiers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addengRef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "engRef", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "engRef");
        }
    }
}
