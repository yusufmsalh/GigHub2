namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAttendence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        GigId = c.Int(nullable: false),
                        AttenderId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GigId, t.AttenderId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttenderId, cascadeDelete: true)
                .ForeignKey("dbo.Gigs", t => t.GigId)
                .Index(t => t.GigId)
                .Index(t => t.AttenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "GigId", "dbo.Gigs");
            DropForeignKey("dbo.Attendences", "AttenderId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendences", new[] { "AttenderId" });
            DropIndex("dbo.Attendences", new[] { "GigId" });
            DropTable("dbo.Attendences");
        }
    }
}
