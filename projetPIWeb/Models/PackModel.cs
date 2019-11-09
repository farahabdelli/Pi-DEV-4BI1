using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projetPIWeb.Models
{
    public class PackModel
    {

        [Key]
        public int PackId { get; set; }
        public int quantity { get; set; }
    }
}