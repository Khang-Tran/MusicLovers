namespace MusicLovers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidation_GigSet_GenreSet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Gigs", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Gigs", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Gigs", "GenreId");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gigs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropIndex("dbo.Gigs", new[] { "GenreId" });
            AlterColumn("dbo.Gigs", "GenreId", c => c.Int());
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Gigs", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            RenameColumn(table: "dbo.Gigs", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Gigs", "Genre_Id");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
