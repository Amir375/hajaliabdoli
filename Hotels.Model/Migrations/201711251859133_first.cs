namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        Age = c.String(),
                        NationalCode = c.String(),
                        Sex = c.String(),
                        Location = c.String(),
                        Username = c.String(),
                        PasswordHash = c.String(),
                        DaysStays = c.String(),
                        PassportNumber = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Name = c.String(),
                        Family = c.String(),
                        Age = c.String(),
                        NationalCode = c.String(),
                        Sex = c.String(),
                        Passenger_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Passenger_Id)
                .Index(t => t.Passenger_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guests", "Passenger_Id", "dbo.People");
            DropForeignKey("dbo.Phones", "Person_Id", "dbo.People");
            DropIndex("dbo.Guests", new[] { "Passenger_Id" });
            DropIndex("dbo.Phones", new[] { "Person_Id" });
            DropTable("dbo.Guests");
            DropTable("dbo.Phones");
            DropTable("dbo.People");
        }
    }
}
