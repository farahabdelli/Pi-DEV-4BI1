namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emna : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Offers", "title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Offers", "title", c => c.String());
        }
    }
}
