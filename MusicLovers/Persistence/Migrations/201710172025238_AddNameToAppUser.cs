namespace MusicLovers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
