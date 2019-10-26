using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
   public  class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string picture { get; set; }
        public string category { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }

        [ForeignKey("ProduitId")]
        public virtual Produit Produit { get; set; }
        public int? ProduitId { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }

    }
}
