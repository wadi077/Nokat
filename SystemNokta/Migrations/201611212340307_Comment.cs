namespace SystemNokta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Nokat_Id", "dbo.Noktas");
            DropIndex("dbo.Comments", new[] { "Nokat_Id" });
            RenameColumn(table: "dbo.Comments", name: "Nokat_Id", newName: "NoktaId");
            AlterColumn("dbo.Comments", "NoktaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "NoktaId");
            AddForeignKey("dbo.Comments", "NoktaId", "dbo.Noktas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "NoktaId", "dbo.Noktas");
            DropIndex("dbo.Comments", new[] { "NoktaId" });
            AlterColumn("dbo.Comments", "NoktaId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "NoktaId", newName: "Nokat_Id");
            CreateIndex("dbo.Comments", "Nokat_Id");
            AddForeignKey("dbo.Comments", "Nokat_Id", "dbo.Noktas", "Id");
        }
    }
}
