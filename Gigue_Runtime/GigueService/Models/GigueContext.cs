using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
//using GigueService.DataObjects;

namespace GigueService.Models
{
    public class GigueContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public GigueContext() : base(connectionStringName)
        {
        } 

        //public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SpokenLanguage> SpokenLanguages { get; set; }
        public DbSet<Photograph> Photographs { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UserMusician> UserMusicians { get; set; }
        public DbSet<UserFavoriteMusician> UserFavoriteMusicians { get; set; }
        public DbSet<UserMusicianRating> UserMusicianRatings { get; set; }
        public DbSet<MusicianInstrument> MusicianInstruments { get; set; }
        public DbSet<MusicianGenre> MusicianGenres { get; set; }
        public DbSet<MusicianLanguage> MusicianLanguages { get; set; }
        public DbSet<MusicianPhotograph> MusicianPhotographs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<UserMusician>().HasKey(x => new { x.AppUserId, x.MusicianId });
            modelBuilder.Entity<UserFavoriteMusician>().HasKey(x => new { x.AppUserId, x.MusicianId });
            modelBuilder.Entity<UserMusicianRating>().HasKey(x => new { x.AppUserId, x.MusicianId });
            modelBuilder.Entity<MusicianInstrument>().HasKey(x => new { x.MusicianId, x.InstrumentId });
            modelBuilder.Entity<MusicianGenre>().HasKey(x => new { x.MusicianId, x.GenreId });
            modelBuilder.Entity<MusicianLanguage>().HasKey(x => new { x.MusicianId, x.SpokenLanguageId });
            modelBuilder.Entity<MusicianPhotograph>().HasKey(x => new { x.MusicianId, x.PhotographId });


        }
    }

}
