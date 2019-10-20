using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }

    }
}
