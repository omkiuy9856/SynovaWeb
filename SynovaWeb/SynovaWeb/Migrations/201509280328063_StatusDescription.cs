namespace SynovaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "description");
        }
    }
}
