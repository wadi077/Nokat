namespace SystemNokta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilePic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "ProfilePic", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "ProfilePic");
        }
    }
}
