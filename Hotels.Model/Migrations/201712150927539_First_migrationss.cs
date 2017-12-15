namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_migrationss : DbMigration
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
                        Price = c.Long(nullable: false),
                        Expire = c.Boolean(nullable: false),
                        PassengerId = c.Int(nullable: false),
                        SuitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("People.Passenger", t => t.PassengerId)
                .ForeignKey("dbo.Suit_Room", t => t.SuitId, cascadeDelete: true)
                .Index(t => t.PassengerId)
                .Index(t => t.SuitId);
            
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
                "dbo.Suit_Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmptyOrFull = c.Boolean(nullable: false),
                        Title = c.String(),
                        Type = c.String(),
                        NumberOfBeds = c.String(),
                        Floor = c.String(),
                        NumberOfRoom = c.String(),
                        NumberOfSingleBeds = c.String(),
                        NumberOfDoubleBeds = c.String(),
                        Capacity = c.Int(nullable: false),
                        Price = c.Long(nullable: false),
                        PhotoPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Bookings", "SuitId", "dbo.Suit_Room");
            DropForeignKey("dbo.Phones", "Person_Id", "People.Person");
            DropForeignKey("dbo.Guests", "PassengerId", "People.Passenger");
            DropForeignKey("dbo.Bookings", "PassengerId", "People.Passenger");
            DropIndex("People.Passenger", new[] { "PassportNumber" });
            DropIndex("People.Passenger", new[] { "Id" });
            DropIndex("People.Employee", new[] { "Username" });
            DropIndex("People.Employee", new[] { "Id" });
            DropIndex("dbo.Phones", new[] { "Person_Id" });
            DropIndex("dbo.Guests", new[] { "PassengerId" });
            DropIndex("People.Person", new[] { "NationalCode" });
            DropIndex("dbo.Bookings", new[] { "SuitId" });
            DropIndex("dbo.Bookings", new[] { "PassengerId" });
            DropTable("People.Passenger");
            DropTable("People.Employee");
            DropTable("dbo.Suit_Room");
            DropTable("dbo.Phones");
            DropTable("dbo.Guests");
            DropTable("People.Person");
            DropTable("dbo.Bookings");
        }
    }
}
