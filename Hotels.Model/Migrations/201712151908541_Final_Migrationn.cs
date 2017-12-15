namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final_Migrationn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SuitOptions", "OptionId", "dbo.Options");
            DropForeignKey("dbo.SuitOptions", "SuitId", "dbo.Suit_Room");
            DropIndex("dbo.SuitOptions", new[] { "OptionId" });
            DropIndex("dbo.SuitOptions", new[] { "SuitId" });
            DropTable("dbo.SuitOptions");
            DropTable("dbo.Options");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuitOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OptionId = c.Int(nullable: false),
                        SuitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SuitOptions", "SuitId");
            CreateIndex("dbo.SuitOptions", "OptionId");
            AddForeignKey("dbo.SuitOptions", "SuitId", "dbo.Suit_Room", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SuitOptions", "OptionId", "dbo.Options", "Id", cascadeDelete: true);
        }
    }
}
