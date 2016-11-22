namespace SystemNokta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nokta2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Noktas", "NoktaContent", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Noktas", "NoktaContent", c => c.String());
        }
    }
}
