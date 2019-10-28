using Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetPIWeb.Models
{
    public class CategoryModel
    {
  
        public string Nom { get; set; }
        public virtual ICollection<Product> Produits { get; set; }
    }
}