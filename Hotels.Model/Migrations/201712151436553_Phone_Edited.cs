namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phone_Edited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "Person_Id", "People.Person");
            DropIndex("dbo.Phones", new[] { "Person_Id" });
            RenameColumn(table: "dbo.Phones", name: "Person_Id", newName: "PersonId");
            AddColumn("dbo.Phones", "PhoneType", c => c.Int(nullable: false));
            AlterColumn("dbo.Phones", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Phones", "PersonId");
            AddForeignKey("dbo.Phones", "PersonId", "People.Person", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "PersonId", "People.Person");
            DropIndex("dbo.Phones", new[] { "PersonId" });
            AlterColumn("dbo.Phones", "PersonId", c => c.Int());
            DropColumn("dbo.Phones", "PhoneType");
            RenameColumn(table: "dbo.Phones", name: "PersonId", newName: "Person_Id");
            CreateIndex("dbo.Phones", "Person_Id");
            AddForeignKey("dbo.Phones", "Person_Id", "People.Person", "Id");
        }
    }
}
