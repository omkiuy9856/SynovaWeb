namespace SynovaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        BookingNo = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        pickup_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Tel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Shipment",
                c => new
                    {
                        ShipmentID = c.Int(nullable: false, identity: true),
                        ShipmentNo = c.Int(nullable: false),
                        BookingID = c.Int(nullable: false),
                        Customer_name = c.String(),
                        receiver_name = c.String(),
                        receiver_address = c.String(),
                        receiver_zipcode = c.Int(nullable: false),
                        receiver_tel = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Decimal(precision: 18, scale: 2),
                        shipment_date = c.DateTime(),
                        pickup_date = c.DateTime(),
                        weight = c.Decimal(precision: 18, scale: 2),
                        StatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipmentID)
                .ForeignKey("dbo.Booking", t => t.BookingID, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.BookingID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.DistributeCenter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipmentID = c.Int(nullable: false),
                        UserID = c.String(),
                        DriverID = c.String(),
                        Driver_DriverId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Driver", t => t.Driver_DriverId)
                .ForeignKey("dbo.Shipment", t => t.ShipmentID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.ShipmentID)
                .Index(t => t.Driver_DriverId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Driver",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        telephone = c.String(),
                        RouteID = c.Int(nullable: false),
                        car_id = c.String(),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Route", t => t.RouteID, cascadeDelete: true)
                .Index(t => t.RouteID);
            
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        area = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        name = c.String(),
                        tel = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        status_name = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipment", "StatusID", "dbo.Status");
            DropForeignKey("dbo.DistributeCenter", "User_UserId", "dbo.User");
            DropForeignKey("dbo.DistributeCenter", "ShipmentID", "dbo.Shipment");
            DropForeignKey("dbo.Driver", "RouteID", "dbo.Route");
            DropForeignKey("dbo.DistributeCenter", "Driver_DriverId", "dbo.Driver");
            DropForeignKey("dbo.Shipment", "BookingID", "dbo.Booking");
            DropForeignKey("dbo.Booking", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Driver", new[] { "RouteID" });
            DropIndex("dbo.DistributeCenter", new[] { "User_UserId" });
            DropIndex("dbo.DistributeCenter", new[] { "Driver_DriverId" });
            DropIndex("dbo.DistributeCenter", new[] { "ShipmentID" });
            DropIndex("dbo.Shipment", new[] { "StatusID" });
            DropIndex("dbo.Shipment", new[] { "BookingID" });
            DropIndex("dbo.Booking", new[] { "CustomerID" });
            DropTable("dbo.Status");
            DropTable("dbo.User");
            DropTable("dbo.Route");
            DropTable("dbo.Driver");
            DropTable("dbo.DistributeCenter");
            DropTable("dbo.Shipment");
            DropTable("dbo.Customer");
            DropTable("dbo.Booking");
        }
    }
}
