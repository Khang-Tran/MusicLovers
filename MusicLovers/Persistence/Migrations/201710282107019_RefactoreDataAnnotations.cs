namespace MusicLovers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoreDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FolloweeId", "FollowerId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
        }
    }
}
