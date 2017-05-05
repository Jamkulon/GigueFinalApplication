namespace GigueService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsPrimary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MusicianGenres", "IsPrimary", c => c.Boolean());
            AddColumn("dbo.MusicianInstruments", "IsPrimary", c => c.Boolean());
            AddColumn("dbo.MusicianLanguages", "IsPrimary", c => c.Boolean());
            AddColumn("dbo.MusicianPhotographs", "IsPrimary", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MusicianPhotographs", "IsPrimary");
            DropColumn("dbo.MusicianLanguages", "IsPrimary");
            DropColumn("dbo.MusicianInstruments", "IsPrimary");
            DropColumn("dbo.MusicianGenres", "IsPrimary");
        }
    }
}
