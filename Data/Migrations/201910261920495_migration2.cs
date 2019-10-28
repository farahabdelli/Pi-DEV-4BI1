namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Boutiques", newName: "Stores");
            RenameTable(name: "dbo.Produits", newName: "Products");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Products", newName: "Produits");
            RenameTable(name: "dbo.Stores", newName: "Boutiques");
        }
    }
}
