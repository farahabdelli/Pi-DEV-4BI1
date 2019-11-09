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
                        idcom = c.Int(),
                    })
                .PrimaryKey(t => t.idbill)
                .ForeignKey("dbo.Commandes", t => t.idcom)
                .Index(t => t.idcom);
            
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
                    })
                .PrimaryKey(t => t.BoutiqueId);
            
            CreateTable(
                "dbo.ProductStores",
                c => new
                    {
                        ProduitId = c.Int(nullable: false),
                        BoutiqueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProduitId, t.BoutiqueId })
                .ForeignKey("dbo.Products", t => t.ProduitId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.BoutiqueId, cascadeDelete: true)
                .Index(t => t.ProduitId)
                .Index(t => t.BoutiqueId);
            
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
                        BrandId = c.Int(),
                        NetworkId = c.Int(),
                    })
                .PrimaryKey(t => t.ProduitId)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .ForeignKey("dbo.Categories", t => t.CategorieId)
                .ForeignKey("dbo.Networks", t => t.NetworkId)
                .Index(t => t.CategorieId)
                .Index(t => t.BrandId)
                .Index(t => t.NetworkId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.CategorieId);
            
            CreateTable(
                "dbo.Networks",
                c => new
                    {
                        NetworkId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.NetworkId);
            
            CreateTable(
                "dbo.CommandeLignes",
                c => new
                    {
                        idcomlig = c.Int(nullable: false, identity: true),
                        quantité = c.Int(nullable: false),
                        montantotal = c.Double(nullable: false),
                        ProduitId = c.Int(),
                        idcom = c.Int(),
                    })
                .PrimaryKey(t => t.idcomlig)
                .ForeignKey("dbo.Commandes", t => t.idcom)
                .ForeignKey("dbo.Products", t => t.ProduitId)
                .Index(t => t.ProduitId)
                .Index(t => t.idcom);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reponses", "QuestionId", "dbo.Categories");
            DropForeignKey("dbo.Promotions", "PackId", "dbo.Packs");
            DropForeignKey("dbo.Packs", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Promotions", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Offers", "ProduitId", "dbo.Products");
            DropForeignKey("dbo.CommandeLignes", "ProduitId", "dbo.Products");
            DropForeignKey("dbo.CommandeLignes", "idcom", "dbo.Commandes");
            DropForeignKey("dbo.ProductStores", "BoutiqueId", "dbo.Stores");
            DropForeignKey("dbo.ProductStores", "ProduitId", "dbo.Products");
            DropForeignKey("dbo.Products", "NetworkId", "dbo.Networks");
            DropForeignKey("dbo.Products", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Bills", "idcom", "dbo.Commandes");
            DropIndex("dbo.Reponses", new[] { "QuestionId" });
            DropIndex("dbo.Packs", new[] { "OfferId" });
            DropIndex("dbo.Promotions", new[] { "PackId" });
            DropIndex("dbo.Promotions", new[] { "OfferId" });
            DropIndex("dbo.Offers", new[] { "ProduitId" });
            DropIndex("dbo.CommandeLignes", new[] { "idcom" });
            DropIndex("dbo.CommandeLignes", new[] { "ProduitId" });
            DropIndex("dbo.Products", new[] { "NetworkId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategorieId" });
            DropIndex("dbo.ProductStores", new[] { "BoutiqueId" });
            DropIndex("dbo.ProductStores", new[] { "ProduitId" });
            DropIndex("dbo.Bills", new[] { "idcom" });
            DropTable("dbo.Reponses");
            DropTable("dbo.Questions");
            DropTable("dbo.Publicites");
            DropTable("dbo.Packs");
            DropTable("dbo.Promotions");
            DropTable("dbo.Offers");
            DropTable("dbo.CommandeLignes");
            DropTable("dbo.Networks");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.ProductStores");
            DropTable("dbo.Stores");
            DropTable("dbo.Commandes");
            DropTable("dbo.Bills");
        }
    }
}
