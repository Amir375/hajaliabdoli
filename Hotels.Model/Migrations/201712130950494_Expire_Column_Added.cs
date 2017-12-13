namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expire_Column_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Expire", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Expire");
        }
    }
}
