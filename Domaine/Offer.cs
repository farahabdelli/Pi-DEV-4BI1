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
        [Required(ErrorMessage = "insert title")]
        [StringLength(25, ErrorMessage = "title must not exceed 50")]
        [MaxLength(50)]
        public string title { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public string picture { get; set; }
        public String category { get; set; }
        [DataType(DataType.Date)]
        public DateTime start_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime end_date { get; set; }


        [ForeignKey("ProduitId")]
        public virtual Product Product { get; set; }
        public int? ProduitId { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }


        // public int MyProperty { get; set; }


    }
}
