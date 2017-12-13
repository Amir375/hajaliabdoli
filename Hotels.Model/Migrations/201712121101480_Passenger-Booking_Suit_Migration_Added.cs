namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassengerBooking_Suit_Migration_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "PassengerId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "SuitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "PassengerId");
            CreateIndex("dbo.Bookings", "SuitId");
            AddForeignKey("dbo.Bookings", "PassengerId", "People.Passenger", "Id");
            AddForeignKey("dbo.Bookings", "SuitId", "dbo.Suits", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "SuitId", "dbo.Suits");
            DropForeignKey("dbo.Bookings", "PassengerId", "People.Passenger");
            DropIndex("dbo.Bookings", new[] { "SuitId" });
            DropIndex("dbo.Bookings", new[] { "PassengerId" });
            DropColumn("dbo.Bookings", "SuitId");
            DropColumn("dbo.Bookings", "PassengerId");
        }
    }
}
