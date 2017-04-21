namespace GigueService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        AppUserId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Email = c.String(),
                        ReceiveAdvertisements = c.Boolean(),
                        IsMusicianForHire = c.Boolean(),
                    })
                .PrimaryKey(t => t.AppUserId);
            
            CreateTable(
                "dbo.UserMusicians",
                c => new
                    {
                        AppUserId = c.Int(nullable: false),
                        MusicianId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUserId, t.MusicianId })
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.MusicianId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.MusicianId);
            
            CreateTable(
                "dbo.Musicians",
                c => new
                    {
                        MusicianId = c.Int(nullable: false, identity: true),
                        StageName = c.String(),
                        CellPhone = c.String(),
                        Biography = c.String(),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.MusicianId);
            
            CreateTable(
                "dbo.UserFavoriteMusicians",
                c => new
                    {
                        AppUserId = c.Int(nullable: false),
                        MusicianId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUserId, t.MusicianId })
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.MusicianId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.MusicianId);
            
            CreateTable(
                "dbo.MusicianGenres",
                c => new
                    {
                        MusicianId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MusicianId, t.GenreId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.MusicianId, cascadeDelete: true)
                .Index(t => t.MusicianId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.MusicianInstruments",
                c => new
                    {
                        MusicianId = c.Int(nullable: false),
                        InstrumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MusicianId, t.InstrumentId })
                .ForeignKey("dbo.Instruments", t => t.InstrumentId, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.MusicianId, cascadeDelete: true)
                .Index(t => t.MusicianId)
                .Index(t => t.InstrumentId);
            
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        InstrumentId = c.Int(nullable: false, identity: true),
                        InstrumentName = c.String(),
                    })
                .PrimaryKey(t => t.InstrumentId);
            
            CreateTable(
                "dbo.MusicianLanguages",
                c => new
                    {
                        MusicianId = c.Int(nullable: false),
                        LanguageSpokenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MusicianId, t.LanguageSpokenId })
                .ForeignKey("dbo.LanguageSpokens", t => t.LanguageSpokenId, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.MusicianId, cascadeDelete: true)
                .Index(t => t.MusicianId)
                .Index(t => t.LanguageSpokenId);
            
            CreateTable(
                "dbo.LanguageSpokens",
                c => new
                    {
                        LanguageSpokenId = c.Int(nullable: false, identity: true),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.LanguageSpokenId);
            
            CreateTable(
                "dbo.MusicianPhotographs",
                c => new
                    {
                        MusicianId = c.Int(nullable: false),
                        PhotographId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MusicianId, t.PhotographId })
                .ForeignKey("dbo.Musicians", t => t.MusicianId, cascadeDelete: true)
                .ForeignKey("dbo.Photographs", t => t.PhotographId, cascadeDelete: true)
                .Index(t => t.MusicianId)
                .Index(t => t.PhotographId);
            
            CreateTable(
                "dbo.Photographs",
                c => new
                    {
                        PhotographId = c.Int(nullable: false, identity: true),
                        PhotographURL = c.String(),
                    })
                .PrimaryKey(t => t.PhotographId);
            
            CreateTable(
                "dbo.UserMusicianRatings",
                c => new
                    {
                        AppUserId = c.Int(nullable: false),
                        MusicianId = c.Int(nullable: false),
                        MusicianRating = c.Int(nullable: false),
                        DateTimeOfRating = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.AppUserId, t.MusicianId })
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.MusicianId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.MusicianId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        MusicianRating = c.String(),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMusicians", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.UserMusicianRatings", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.UserMusicianRatings", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.MusicianPhotographs", "PhotographId", "dbo.Photographs");
            DropForeignKey("dbo.MusicianPhotographs", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.MusicianLanguages", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.MusicianLanguages", "LanguageSpokenId", "dbo.LanguageSpokens");
            DropForeignKey("dbo.MusicianInstruments", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.MusicianInstruments", "InstrumentId", "dbo.Instruments");
            DropForeignKey("dbo.MusicianGenres", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.MusicianGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.UserFavoriteMusicians", "MusicianId", "dbo.Musicians");
            DropForeignKey("dbo.UserFavoriteMusicians", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserMusicians", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.UserMusicianRatings", new[] { "MusicianId" });
            DropIndex("dbo.UserMusicianRatings", new[] { "AppUserId" });
            DropIndex("dbo.MusicianPhotographs", new[] { "PhotographId" });
            DropIndex("dbo.MusicianPhotographs", new[] { "MusicianId" });
            DropIndex("dbo.MusicianLanguages", new[] { "LanguageSpokenId" });
            DropIndex("dbo.MusicianLanguages", new[] { "MusicianId" });
            DropIndex("dbo.MusicianInstruments", new[] { "InstrumentId" });
            DropIndex("dbo.MusicianInstruments", new[] { "MusicianId" });
            DropIndex("dbo.MusicianGenres", new[] { "GenreId" });
            DropIndex("dbo.MusicianGenres", new[] { "MusicianId" });
            DropIndex("dbo.UserFavoriteMusicians", new[] { "MusicianId" });
            DropIndex("dbo.UserFavoriteMusicians", new[] { "AppUserId" });
            DropIndex("dbo.UserMusicians", new[] { "MusicianId" });
            DropIndex("dbo.UserMusicians", new[] { "AppUserId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.UserMusicianRatings");
            DropTable("dbo.Photographs");
            DropTable("dbo.MusicianPhotographs");
            DropTable("dbo.LanguageSpokens");
            DropTable("dbo.MusicianLanguages");
            DropTable("dbo.Instruments");
            DropTable("dbo.MusicianInstruments");
            DropTable("dbo.Genres");
            DropTable("dbo.MusicianGenres");
            DropTable("dbo.UserFavoriteMusicians");
            DropTable("dbo.Musicians");
            DropTable("dbo.UserMusicians");
            DropTable("dbo.AppUsers");
        }
    }
}
