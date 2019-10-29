namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahmed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        idbill = c.Int(nullable: false, identity: true),
                        date_created = c.DateTime(nullable: false),
                        date_end = c.DateTime(nullable: false),
                        payed = c.Boolean(nullable: false),
                        commandeFK = c.Int(nullable: false),
                        commande_idcom = c.Int(),
                    })
                .PrimaryKey(t => t.idbill)
                .ForeignKey("dbo.Commandes", t => t.commande_idcom)
                .Index(t => t.commande_idcom);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        idcom = c.Int(nullable: false, identity: true),
                        prix = c.Double(nullable: false),
                        nbrcom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idcom);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        BoutiqueId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Ville = c.String(nullable: false, maxLength: 50),
                        Adresse = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        tel = c.Int(nullable: false),
                        type = c.String(),
                        heure_ouv = c.String(),
                        heure_ferm = c.String(),
                        Stock_idStock = c.Int(),
                    })
                .PrimaryKey(t => t.BoutiqueId)
                .ForeignKey("dbo.Stocks", t => t.Stock_idStock)
                .Index(t => t.Stock_idStock);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.CategorieId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProduitId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Prix = c.Double(nullable: false),
                        Quantite = c.Int(nullable: false),
                        Image = c.String(),
                        CategorieId = c.Int(),
                    })
                .PrimaryKey(t => t.ProduitId)
                .ForeignKey("dbo.Categories", t => t.CategorieId)
                .Index(t => t.CategorieId);
            
            CreateTable(
                "dbo.CommandeLignes",
                c => new
                    {
                        idcomlig = c.Int(nullable: false, identity: true),
                        quantité = c.Int(nullable: false),
                        montantotal = c.Double(nullable: false),
                        commandeFK = c.Int(nullable: false),
                        commande_idcom = c.Int(),
                    })
                .PrimaryKey(t => t.idcomlig)
                .ForeignKey("dbo.Commandes", t => t.commande_idcom)
                .Index(t => t.commande_idcom);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        picture = c.String(),
                        category = c.String(),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                        ProduitId = c.Int(),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.Products", t => t.ProduitId)
                .Index(t => t.ProduitId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                        percentage = c.Single(nullable: false),
                        OfferId = c.Int(),
                        PackId = c.Int(),
                    })
                .PrimaryKey(t => t.PromotionId)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .ForeignKey("dbo.Packs", t => t.PackId)
                .Index(t => t.OfferId)
                .Index(t => t.PackId);
            
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        PackId = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        OfferId = c.Int(),
                    })
                .PrimaryKey(t => t.PackId)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .Index(t => t.OfferId);
            
            CreateTable(
                "dbo.Publicites",
                c => new
                    {
                        PubliciteId = c.Int(nullable: false, identity: true),
                        NomPartenaire = c.String(),
                        TitrePub = c.String(),
                        DescriptionPub = c.String(),
                        Image = c.String(),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        NbVues = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PubliciteId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                        DatePost = c.DateTime(nullable: false),
                        NbVues = c.Int(nullable: false),
                        NbLikes = c.Int(nullable: false),
                        NbDislikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                        DatePost = c.DateTime(nullable: false),
                        NbVues = c.Int(nullable: false),
                        NbLikes = c.Int(nullable: false),
                        NbDislikes = c.Int(nullable: false),
                        QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.ReponseId)
                .ForeignKey("dbo.Categories", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        idStock = c.Int(nullable: false, identity: true),
                        quantite_entrante = c.Int(nullable: false),
                        quantite_sortante = c.Int(nullable: false),
                        quantite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idStock);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "Stock_idStock", "dbo.Stocks");
            DropForeignKey("dbo.Reponses", "QuestionId", "dbo.Categories");
            DropForeignKey("dbo.Promotions", "PackId", "dbo.Packs");
            DropForeignKey("dbo.Packs", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Promotions", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Offers", "ProduitId", "dbo.Products");
            DropForeignKey("dbo.CommandeLignes", "commande_idcom", "dbo.Commandes");
            DropForeignKey("dbo.Products", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.Bills", "commande_idcom", "dbo.Commandes");
            DropIndex("dbo.Reponses", new[] { "QuestionId" });
            DropIndex("dbo.Packs", new[] { "OfferId" });
            DropIndex("dbo.Promotions", new[] { "PackId" });
            DropIndex("dbo.Promotions", new[] { "OfferId" });
            DropIndex("dbo.Offers", new[] { "ProduitId" });
            DropIndex("dbo.CommandeLignes", new[] { "commande_idcom" });
            DropIndex("dbo.Products", new[] { "CategorieId" });
            DropIndex("dbo.Stores", new[] { "Stock_idStock" });
            DropIndex("dbo.Bills", new[] { "commande_idcom" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Reponses");
            DropTable("dbo.Questions");
            DropTable("dbo.Publicites");
            DropTable("dbo.Packs");
            DropTable("dbo.Promotions");
            DropTable("dbo.Offers");
            DropTable("dbo.CommandeLignes");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Stores");
            DropTable("dbo.Commandes");
            DropTable("dbo.Bills");
        }
    }
}
