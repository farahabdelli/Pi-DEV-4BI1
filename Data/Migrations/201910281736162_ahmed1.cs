namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahmed1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bills", name: "commande_idcom", newName: "idcom");
            RenameIndex(table: "dbo.Bills", name: "IX_commande_idcom", newName: "IX_idcom");
            AddColumn("dbo.CommandeLignes", "ProduitId", c => c.Int());
            CreateIndex("dbo.CommandeLignes", "ProduitId");
            AddForeignKey("dbo.CommandeLignes", "ProduitId", "dbo.Products", "ProduitId");
            DropColumn("dbo.Bills", "commandeFK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "commandeFK", c => c.Int(nullable: false));
            DropForeignKey("dbo.CommandeLignes", "ProduitId", "dbo.Products");
            DropIndex("dbo.CommandeLignes", new[] { "ProduitId" });
            DropColumn("dbo.CommandeLignes", "ProduitId");
            RenameIndex(table: "dbo.Bills", name: "IX_idcom", newName: "IX_commande_idcom");
            RenameColumn(table: "dbo.Bills", name: "idcom", newName: "commande_idcom");
        }
    }
}