namespace GigueService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpassword2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "PassWord", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUsers", "PassWord");
        }
    }
}
