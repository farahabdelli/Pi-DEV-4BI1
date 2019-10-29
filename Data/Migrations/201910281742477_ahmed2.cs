namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahmed2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CommandeLignes", name: "commande_idcom", newName: "idcom");
            RenameIndex(table: "dbo.CommandeLignes", name: "IX_commande_idcom", newName: "IX_idcom");
            DropColumn("dbo.CommandeLignes", "commandeFK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommandeLignes", "commandeFK", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.CommandeLignes", name: "IX_idcom", newName: "IX_commande_idcom");
            RenameColumn(table: "dbo.CommandeLignes", name: "idcom", newName: "commande_idcom");
        }
    }
}
