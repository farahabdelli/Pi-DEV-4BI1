namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Networks",
                c => new
                    {
                        NetworkId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.NetworkId);
            
            AddColumn("dbo.Products", "BrandId", c => c.Int());
            AddColumn("dbo.Products", "NetworkId", c => c.Int());
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "NetworkId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "BrandId");
            AddForeignKey("dbo.Products", "NetworkId", "dbo.Networks", "NetworkId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "NetworkId", "dbo.Networks");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "NetworkId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropColumn("dbo.Products", "NetworkId");
            DropColumn("dbo.Products", "BrandId");
            DropTable("dbo.Networks");
            DropTable("dbo.Brands");
        }
    }
}
