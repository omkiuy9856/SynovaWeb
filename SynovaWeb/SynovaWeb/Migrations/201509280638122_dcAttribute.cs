namespace SynovaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dcAttribute : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DistributeCenter", "Driver_DriverId", "dbo.Driver");
            DropForeignKey("dbo.DistributeCenter", "User_UserId", "dbo.User");
            DropIndex("dbo.DistributeCenter", new[] { "Driver_DriverId" });
            DropIndex("dbo.DistributeCenter", new[] { "User_UserId" });
            DropColumn("dbo.DistributeCenter", "DriverID");
            DropColumn("dbo.DistributeCenter", "UserID");
            RenameColumn(table: "dbo.DistributeCenter", name: "Driver_DriverId", newName: "DriverID");
            RenameColumn(table: "dbo.DistributeCenter", name: "User_UserId", newName: "UserID");
            AlterColumn("dbo.DistributeCenter", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.DistributeCenter", "DriverID", c => c.Int(nullable: false));
            AlterColumn("dbo.DistributeCenter", "DriverID", c => c.Int(nullable: false));
            AlterColumn("dbo.DistributeCenter", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.DistributeCenter", "UserID");
            CreateIndex("dbo.DistributeCenter", "DriverID");
            AddForeignKey("dbo.DistributeCenter", "DriverID", "dbo.Driver", "DriverId", cascadeDelete: true);
            AddForeignKey("dbo.DistributeCenter", "UserID", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DistributeCenter", "UserID", "dbo.User");
            DropForeignKey("dbo.DistributeCenter", "DriverID", "dbo.Driver");
            DropIndex("dbo.DistributeCenter", new[] { "DriverID" });
            DropIndex("dbo.DistributeCenter", new[] { "UserID" });
            AlterColumn("dbo.DistributeCenter", "UserID", c => c.Int());
            AlterColumn("dbo.DistributeCenter", "DriverID", c => c.Int());
            AlterColumn("dbo.DistributeCenter", "DriverID", c => c.String());
            AlterColumn("dbo.DistributeCenter", "UserID", c => c.String());
            RenameColumn(table: "dbo.DistributeCenter", name: "UserID", newName: "User_UserId");
            RenameColumn(table: "dbo.DistributeCenter", name: "DriverID", newName: "Driver_DriverId");
            AddColumn("dbo.DistributeCenter", "UserID", c => c.String());
            AddColumn("dbo.DistributeCenter", "DriverID", c => c.String());
            CreateIndex("dbo.DistributeCenter", "User_UserId");
            CreateIndex("dbo.DistributeCenter", "Driver_DriverId");
            AddForeignKey("dbo.DistributeCenter", "User_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.DistributeCenter", "Driver_DriverId", "dbo.Driver", "DriverId");
        }
    }
}
