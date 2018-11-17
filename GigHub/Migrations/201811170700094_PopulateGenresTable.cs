namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Generes (Id,Name) Values (1,'Jazz')");
            Sql("Insert into Generes (Id,Name) Values (2,'Blues')");
            Sql("Insert into Generes (Id,Name) Values (3,'Rock')");

        }
        
        public override void Down()
        {
            Sql("Delete From Generes Where Id In (1,2,3,4 )");
        }
    }
}
