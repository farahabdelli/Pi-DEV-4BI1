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
        public projetPIContext():base("Name=alias")
        {

        }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Boutique> Boutiques { get; set; }

    }
}
