namespace Hotels.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Username", c => c.String(maxLength: 20));
            CreateIndex("dbo.People", "Username", unique: true);
            DropColumn("dbo.People", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Password", c => c.String());
            DropIndex("dbo.People", new[] { "Username" });
            AlterColumn("dbo.People", "Username", c => c.String());
        }
    }
}
