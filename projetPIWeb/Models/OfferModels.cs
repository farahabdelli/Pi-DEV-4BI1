using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetPIWeb.Models
{
    public class OfferModels
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
        public IEnumerable<SelectListItem> Products { get; set; }

        public int? ProduitId { get; set; }

    }
}