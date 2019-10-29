using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        public string Nom { get; set; }


    }
}
