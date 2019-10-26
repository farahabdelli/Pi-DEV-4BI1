using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
   public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }
        public string description { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public float percentage { get; set; }

        [ForeignKey("OfferId")]
        public virtual Offer Offer { get; set; }
        public int? OfferId { get; set; }

        [ForeignKey("PackId")]
        public virtual Pack Pack { get; set; }
        public int? PackId { get; set; }

    }
}
