using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projetPIWeb.Models
{
    public class projetPIWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public projetPIWebContext() : base("name=projetPIWebContext")
        {
        }

        public System.Data.Entity.DbSet<projetPIWeb.Models.ProductStoreModel> ProductStoreModels { get; set; }

        public System.Data.Entity.DbSet<Domaine.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Domaine.Store> Stores { get; set; }
    }
}
