namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Room_Suit_combined_and_chenge : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Suits", newName: "Suit_Room");
            AddColumn("dbo.Suit_Room", "Type", c => c.String());
            DropColumn("dbo.Suit_Room", "EntryDate");
            DropColumn("dbo.Suit_Room", "DateOfDeparture");
            DropColumn("dbo.Suit_Room", "SuitType");
            DropColumn("dbo.Suit_Room", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suit_Room", "Amount", c => c.String());
            AddColumn("dbo.Suit_Room", "SuitType", c => c.String());
            AddColumn("dbo.Suit_Room", "DateOfDeparture", c => c.DateTime());
            AddColumn("dbo.Suit_Room", "EntryDate", c => c.DateTime());
            DropColumn("dbo.Suit_Room", "Type");
            RenameTable(name: "dbo.Suit_Room", newName: "Suits");
        }
    }
}
