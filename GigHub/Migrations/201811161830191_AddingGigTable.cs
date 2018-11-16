namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Artist_Id = c.String(maxLength: 128),
                        Genere_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .ForeignKey("dbo.Generes", t => t.Genere_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genere_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genere_Id", "dbo.Generes");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genere_Id" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropTable("dbo.Gigs");
            DropTable("dbo.Generes");
        }
    }
}
