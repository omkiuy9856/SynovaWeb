namespace SynovaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DistributeCenter", "current_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.DistributeCenter", "user_tel", c => c.Int(nullable: false));
            AddColumn("dbo.DistributeCenter", "driver_tel", c => c.Int(nullable: false));
            AddColumn("dbo.DistributeCenter", "route_name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DistributeCenter", "route_name");
            DropColumn("dbo.DistributeCenter", "driver_tel");
            DropColumn("dbo.DistributeCenter", "user_tel");
            DropColumn("dbo.DistributeCenter", "current_date");
        }
    }
}
