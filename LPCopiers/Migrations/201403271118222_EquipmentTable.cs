namespace LPCopiers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblEquipment",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        EngRef = c.String(),
                        serialNo = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        Company = c.String(),
                        Contact = c.String(),
                        Location = c.String(),
                        Engineer_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.UserProfile", t => t.Engineer_UserId)
                .Index(t => t.Engineer_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.tblEquipment", new[] { "Engineer_UserId" });
            DropForeignKey("dbo.tblEquipment", "Engineer_UserId", "dbo.UserProfile");
            DropTable("dbo.tblEquipment");
        }
    }
}
