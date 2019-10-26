using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Category
    {
        [Key]
        public int CategorieId { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<Product> Produits { get; set; }

        //propljnjl  

    }
}
