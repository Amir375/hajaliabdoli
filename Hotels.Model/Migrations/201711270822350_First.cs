namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmptyorFull = c.String(),
                        Level = c.String(),
                        TotalPrice = c.String(),
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
                        Price = c.String(),
                        Masaj = c.Boolean(nullable: false),
                        MyProperty = c.Boolean(nullable: false),
                        Parking = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfBeds = c.String(),
                        NumberOfRoom = c.String(),
                        Floor = c.String(),
                        Price = c.Int(nullable: false),
                        Booking_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.Booking_Id)
                .Index(t => t.Booking_Id);
            
            CreateTable(
                "dbo.Suits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfBeds = c.String(),
                        NumberOfRoom = c.String(),
                        Floor = c.String(),
                        Price = c.Int(nullable: false),
                        Booking_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.Booking_Id)
                .Index(t => t.Booking_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Family = c.String(nullable: false, maxLength: 50),
                        Age = c.String(maxLength: 3),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        Sex = c.String(),
                        Location = c.String(maxLength: 100),
                        Username = c.String(maxLength: 20),
                        PasswordHash = c.String(),
                        DaysStays = c.String(),
                        PassportNumber = c.String(maxLength: 20),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NationalCode, unique: true)
                .Index(t => t.Username, unique: true)
                .Index(t => t.PassportNumber, unique: true);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Family = c.String(nullable: false, maxLength: 50),
                        Age = c.String(),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        Sex = c.String(),
                        Passenger_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Passenger_Id)
                .Index(t => t.NationalCode, unique: true)
                .Index(t => t.Passenger_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guests", "Passenger_Id", "dbo.People");
            DropForeignKey("dbo.Phones", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Suits", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.Rooms", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "Option_Id", "dbo.Options");
            DropIndex("dbo.Guests", new[] { "Passenger_Id" });
            DropIndex("dbo.Guests", new[] { "NationalCode" });
            DropIndex("dbo.Phones", new[] { "Person_Id" });
            DropIndex("dbo.People", new[] { "PassportNumber" });
            DropIndex("dbo.People", new[] { "Username" });
            DropIndex("dbo.People", new[] { "NationalCode" });
            DropIndex("dbo.Suits", new[] { "Booking_Id" });
            DropIndex("dbo.Rooms", new[] { "Booking_Id" });
            DropIndex("dbo.Bookings", new[] { "Option_Id" });
            DropTable("dbo.Guests");
            DropTable("dbo.Phones");
            DropTable("dbo.People");
            DropTable("dbo.Suits");
            DropTable("dbo.Rooms");
            DropTable("dbo.Options");
            DropTable("dbo.Bookings");
        }
    }
}
