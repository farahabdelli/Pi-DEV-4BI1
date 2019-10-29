namespace projetPIWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProduitModels", "CategorieId", c => c.Int());
            AddColumn("dbo.ProduitModels", "BrandId", c => c.Int());
            AddColumn("dbo.ProduitModels", "NetworkId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProduitModels", "NetworkId");
            DropColumn("dbo.ProduitModels", "BrandId");
            DropColumn("dbo.ProduitModels", "CategorieId");
        }
    }
}
