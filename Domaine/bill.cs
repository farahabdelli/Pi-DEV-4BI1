using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Bill
    {[Key]
        public int idbill { get; set; }
        [DataType(DataType.Date)]
        public DateTime date_created { get; set; }
        [DataType(DataType.Date)]
        public DateTime date_end { get; set; }
        public Boolean payed { get; set; }
        [ForeignKey("idcom")]
        public virtual Commande commande { get; set; }
        public int? idcom { get; set; }
    }
}
