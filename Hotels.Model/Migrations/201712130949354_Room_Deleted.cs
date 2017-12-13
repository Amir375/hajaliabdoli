namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Room_Deleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Option_Id", "dbo.Options");
            DropIndex("dbo.Bookings", new[] { "Room_Id" });
            DropIndex("dbo.Rooms", new[] { "Option_Id" });
            DropColumn("dbo.Bookings", "Room_Id");
            DropColumn("dbo.Options", "RoomId");
            DropTable("dbo.Rooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        DateOfDeparture = c.DateTime(nullable: false),
                        EmptyOrFull = c.Boolean(nullable: false),
                        RoomType = c.String(),
                        NumberOfBeds = c.String(),
                        Floor = c.String(),
                        NumberOfSingleBeds = c.String(),
                        NumberOfDoubleBeds = c.String(),
                        Capacity = c.String(),
                        BookingId = c.Int(nullable: false),
                        Option_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Options", "RoomId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Room_Id", c => c.Int());
            CreateIndex("dbo.Rooms", "Option_Id");
            CreateIndex("dbo.Bookings", "Room_Id");
            AddForeignKey("dbo.Rooms", "Option_Id", "dbo.Options", "Id");
            AddForeignKey("dbo.Bookings", "Room_Id", "dbo.Rooms", "Id");
        }
    }
}
