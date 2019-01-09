namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFollowFeature : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Followings", newName: "FollowingRelations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FollowingRelations", newName: "Followings");
        }
    }
}
