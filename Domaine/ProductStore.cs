using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class ProductStore
    {
        [Key]
        [Column(Order = 1)]
        public int ProduitId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BoutiqueId { get; set; }
        public virtual Product Productt { get; set; }
        public virtual Store Store { get; set; }

        public int count { get; set; }
    }
}
