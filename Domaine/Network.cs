using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Network
    {
        [Key]
        public int NetworkId { get; set; }
        [Display(Name = "Network")]
        public string Nom { get; set; }


    }
}
