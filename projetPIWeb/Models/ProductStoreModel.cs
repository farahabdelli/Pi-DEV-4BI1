using Domaine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projetPIWeb.Models
{
    public class ProductStoreModel
    {
        [Key]
        [Column(Order=1)]
        public int ProduitId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BoutiqueId { get; set; }
        public virtual Product Productt  { get; set; }
        public virtual Store Store { get; set; }
        public int count { get; set; }

    }
}