namespace GigueService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "IsMusician", c => c.Boolean());
            AddColumn("dbo.Musicians", "IsMusicianForHire", c => c.Boolean());
            DropColumn("dbo.AppUsers", "IsMusicianForHire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "IsMusicianForHire", c => c.Boolean());
            DropColumn("dbo.Musicians", "IsMusicianForHire");
            DropColumn("dbo.AppUsers", "IsMusician");
        }
    }
}
