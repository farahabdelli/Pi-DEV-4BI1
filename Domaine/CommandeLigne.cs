using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
   public class CommandeLigne
    {
        [Key]
        [Column(Order = 0)]
        public int idcomlig { get; set; }
        public int quantité { get; set; }
        [DataType(DataType.Currency)]
        public double montantotal { get; set; }
      //  [Key]
        //[Column(Order = 1)]
        // public produit produit { get; set; }
       // [Key]
        //[Column(Order = 2)]
        //  public User User { get; set; }
        public Commande commande { get; set; }
        public int commandeFK { get; set; }
    }
}
