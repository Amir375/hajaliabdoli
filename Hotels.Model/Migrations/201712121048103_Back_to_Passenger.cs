namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Back_to_Passenger : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "PassengerId", "People.Passenger");
            DropForeignKey("dbo.Bookings", "SuitId", "dbo.Suits");
            DropIndex("dbo.Bookings", new[] { "PassengerId" });
            DropIndex("dbo.Bookings", new[] { "SuitId" });
            DropColumn("dbo.Bookings", "PassengerId");
            DropColumn("dbo.Bookings", "SuitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "SuitId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "PassengerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "SuitId");
            CreateIndex("dbo.Bookings", "PassengerId");
            AddForeignKey("dbo.Bookings", "SuitId", "dbo.Suits", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "PassengerId", "People.Passenger", "Id");
        }
    }
}
