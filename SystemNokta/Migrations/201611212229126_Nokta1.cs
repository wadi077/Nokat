namespace SystemNokta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nokta1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Noktas", "UserAccount_Id", "dbo.UserAccounts");
            DropIndex("dbo.Noktas", new[] { "UserAccount_Id" });
            RenameColumn(table: "dbo.Noktas", name: "UserAccount_Id", newName: "UserId");
            AlterColumn("dbo.Noktas", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Noktas", "UserId");
            AddForeignKey("dbo.Noktas", "UserId", "dbo.UserAccounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noktas", "UserId", "dbo.UserAccounts");
            DropIndex("dbo.Noktas", new[] { "UserId" });
            AlterColumn("dbo.Noktas", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Noktas", name: "UserId", newName: "UserAccount_Id");
            CreateIndex("dbo.Noktas", "UserAccount_Id");
            AddForeignKey("dbo.Noktas", "UserAccount_Id", "dbo.UserAccounts", "Id");
        }
    }
}
