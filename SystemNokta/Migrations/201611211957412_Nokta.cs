namespace SystemNokta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nokta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(nullable: false),
                        Nokat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Noktas", t => t.Nokat_Id)
                .Index(t => t.Nokat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Nokat_Id", "dbo.Noktas");
            DropIndex("dbo.Comments", new[] { "Nokat_Id" });
            DropTable("dbo.Comments");
        }
    }
}
