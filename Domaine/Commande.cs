using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Commande
    {[Key]
        public int idcom { get; set; }
        [DataType(DataType.Currency)]
        public double prix { get; set; }
        public int nbrcom { get; set; }
        public IEnumerable<CommandeLigne> commandeligne { get; set; }

        //commentaire
    }
}
