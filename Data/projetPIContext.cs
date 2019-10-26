using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine;


namespace Data
{
  public  class projetPIContext : DbContext
    {
        public projetPIContext():base("projetPIDataBase")
        {

        }
        public DbSet<Product> Produits { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Boutiques { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<CommandeLigne> CommandeLignes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public DbSet<Publicite> Publicites { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Offer> Offers { get; set; }

    }
}
