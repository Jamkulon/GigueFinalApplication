namespace GigueService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class musicianUpdataed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpokenLanguages", "Musician_MusicianId", "dbo.Musicians");
            DropIndex("dbo.SpokenLanguages", new[] { "Musician_MusicianId" });
            DropColumn("dbo.SpokenLanguages", "Musician_MusicianId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpokenLanguages", "Musician_MusicianId", c => c.Int());
            CreateIndex("dbo.SpokenLanguages", "Musician_MusicianId");
            AddForeignKey("dbo.SpokenLanguages", "Musician_MusicianId", "dbo.Musicians", "MusicianId");
        }
    }
}
