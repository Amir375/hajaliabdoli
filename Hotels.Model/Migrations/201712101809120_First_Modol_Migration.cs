namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_Modol_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DaysStays = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        DateOfDeparture = c.DateTime(nullable: false),
                        NumberOfPerson = c.Int(nullable: false),
                        NumberOfChild = c.Int(nullable: false),
                        SuitOrRoom = c.String(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "People.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Family = c.String(nullable: false, maxLength: 50),
                        Age = c.String(maxLength: 3),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        Sex = c.String(),
                        Location = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NationalCode, unique: true);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        Age = c.String(),
                        NationalCode = c.String(),
                        Sex = c.String(),
                        PassengerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("People.Passenger", t => t.PassengerId)
                .Index(t => t.PassengerId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("People.Person", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Suits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(),
                        DateOfDeparture = c.DateTime(),
                        EmptyOrFull = c.Boolean(nullable: false),
                        Title = c.String(),
                        SuitType = c.String(),
                        NumberOfBeds = c.String(),
                        Floor = c.String(),
                        NumberOfRoom = c.String(),
                        NumberOfSingleBeds = c.String(),
                        NumberOfDoubleBeds = c.String(),
                        Capacity = c.Int(nullable: false),
                        Price = c.Long(nullable: false),
                        PhotoPath = c.String(),
                        Amount = c.String(),
                        Option_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Options", t => t.Option_Id)
                .Index(t => t.Option_Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estakhr = c.Boolean(nullable: false),
                        Internet = c.Boolean(nullable: false),
                        Masaj = c.Boolean(nullable: false),
                        Parking = c.Boolean(nullable: false),
                        RoomId = c.Int(nullable: false),
                        SuitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Options", t => t.Option_Id)
                .Index(t => t.Option_Id);
            
            CreateTable(
                "dbo.SuitBookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuitId = c.Int(nullable: false),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Suits", t => t.SuitId, cascadeDelete: true)
                .Index(t => t.SuitId)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.PassengerBookings",
                c => new
                    {
                        Passenger_Id = c.Int(nullable: false),
                        Booking_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Passenger_Id, t.Booking_Id })
                .ForeignKey("People.Passenger", t => t.Passenger_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bookings", t => t.Booking_Id, cascadeDelete: true)
                .Index(t => t.Passenger_Id)
                .Index(t => t.Booking_Id);
            
            CreateTable(
                "dbo.SuitBookings1",
                c => new
                    {
                        Suit_Id = c.Int(nullable: false),
                        Booking_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Suit_Id, t.Booking_Id })
                .ForeignKey("dbo.Suits", t => t.Suit_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bookings", t => t.Booking_Id, cascadeDelete: true)
                .Index(t => t.Suit_Id)
                .Index(t => t.Booking_Id);
            
            CreateTable(
                "People.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        PasswordHash = c.String(),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("People.Person", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "People.Passenger",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PassportNumber = c.String(nullable: false, maxLength: 9),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("People.Person", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.PassportNumber, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("People.Passenger", "Id", "People.Person");
            DropForeignKey("People.Employee", "Id", "People.Person");
            DropForeignKey("dbo.SuitBookings", "SuitId", "dbo.Suits");
            DropForeignKey("dbo.SuitBookings", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Suits", "Option_Id", "dbo.Options");
            DropForeignKey("dbo.Rooms", "Option_Id", "dbo.Options");
            DropForeignKey("dbo.Bookings", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.SuitBookings1", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.SuitBookings1", "Suit_Id", "dbo.Suits");
            DropForeignKey("dbo.Phones", "Person_Id", "People.Person");
            DropForeignKey("dbo.Guests", "PassengerId", "People.Passenger");
            DropForeignKey("dbo.PassengerBookings", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.PassengerBookings", "Passenger_Id", "People.Passenger");
            DropIndex("People.Passenger", new[] { "PassportNumber" });
            DropIndex("People.Passenger", new[] { "Id" });
            DropIndex("People.Employee", new[] { "Username" });
            DropIndex("People.Employee", new[] { "Id" });
            DropIndex("dbo.SuitBookings1", new[] { "Booking_Id" });
            DropIndex("dbo.SuitBookings1", new[] { "Suit_Id" });
            DropIndex("dbo.PassengerBookings", new[] { "Booking_Id" });
            DropIndex("dbo.PassengerBookings", new[] { "Passenger_Id" });
            DropIndex("dbo.SuitBookings", new[] { "BookingId" });
            DropIndex("dbo.SuitBookings", new[] { "SuitId" });
            DropIndex("dbo.Rooms", new[] { "Option_Id" });
            DropIndex("dbo.Suits", new[] { "Option_Id" });
            DropIndex("dbo.Phones", new[] { "Person_Id" });
            DropIndex("dbo.Guests", new[] { "PassengerId" });
            DropIndex("People.Person", new[] { "NationalCode" });
            DropIndex("dbo.Bookings", new[] { "Room_Id" });
            DropTable("People.Passenger");
            DropTable("People.Employee");
            DropTable("dbo.SuitBookings1");
            DropTable("dbo.PassengerBookings");
            DropTable("dbo.SuitBookings");
            DropTable("dbo.Rooms");
            DropTable("dbo.Options");
            DropTable("dbo.Suits");
            DropTable("dbo.Phones");
            DropTable("dbo.Guests");
            DropTable("People.Person");
            DropTable("dbo.Bookings");
        }
    }
}
