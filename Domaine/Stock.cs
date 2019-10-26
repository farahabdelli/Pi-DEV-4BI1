using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Stock
    {
        [Key]
        public int idStock { get; set; }

        [Range(0, int.MaxValue)]
        public int quantite_entrante { get; set; }
        [Range(0, int.MaxValue)]
        public int quantite_sortante { get; set; }
        [Range(0, int.MaxValue)]
        public int quantite { get; set; }
        public virtual ICollection<Store> Boutiques { get; set; }
    }
}
