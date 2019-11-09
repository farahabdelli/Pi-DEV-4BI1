using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Pack
    {
        [Key]
        public int PackId { get; set; }
        [Range(0, int.MaxValue)]
        public int quantity { get; set; }

        [ForeignKey("OfferId")]
        public virtual Offer Offer { get; set; }
        public int? OfferId { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
