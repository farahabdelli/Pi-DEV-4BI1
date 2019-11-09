using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetPIWeb.Models
{
    public class PromotionModel
    {
        [Key]
        public int PromotionId { get; set; }
        public string description { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public float percentage { get; set; }

    }
}