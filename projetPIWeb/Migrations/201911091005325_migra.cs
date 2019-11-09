namespace projetPIWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migra : DbMigration
    {
        public override void Up()
        {
           
            
          
            CreateTable(
                "dbo.ProductStoreModels",
                c => new
                    {
                        ProduitId = c.Int(nullable: false),
                        BoutiqueId = c.Int(nullable: false),
                        count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProduitId, t.BoutiqueId })
                .ForeignKey("dbo.Products", t => t.ProduitId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.BoutiqueId, cascadeDelete: true)
                .Index(t => t.ProduitId)
                .Index(t => t.BoutiqueId);
            
            CreateTable(
                "dbo.ProduitModels",
                c => new
                    {
                        ProduitId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                        Description = c.String(),
                        Prix = c.Double(nullable: false),
                        Quantite = c.Int(nullable: false),
                        CategorieId = c.Int(),
                        BrandId = c.Int(),
                        NetworkId = c.Int(),
                    })
                .PrimaryKey(t => t.ProduitId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StoreModels",
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductStoreModels", "BoutiqueId", "dbo.Stores");
            DropForeignKey("dbo.ProductStoreModels", "ProduitId", "dbo.Products");
            DropForeignKey("dbo.ProductStores", "BoutiqueId", "dbo.Stores");
            DropForeignKey("dbo.ProductStores", "ProduitId", "dbo.Products");
            DropForeignKey("dbo.Products", "NetworkId", "dbo.Networks");
            DropForeignKey("dbo.Products", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductStoreModels", new[] { "BoutiqueId" });
            DropIndex("dbo.ProductStoreModels", new[] { "ProduitId" });
            DropIndex("dbo.ProductStores", new[] { "BoutiqueId" });
            DropIndex("dbo.ProductStores", new[] { "ProduitId" });
            DropIndex("dbo.Products", new[] { "NetworkId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategorieId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StoreModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProduitModels");
            DropTable("dbo.ProductStoreModels");
            DropTable("dbo.Stores");
            DropTable("dbo.ProductStores");
            DropTable("dbo.Networks");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
