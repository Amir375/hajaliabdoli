namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Again : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "DaysStays", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "DaysStays", c => c.Int(nullable: false));
        }
    }
}
