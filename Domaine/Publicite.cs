using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
   public class Publicite
    {
        public int PubliciteId { get; set; }
        public string NomPartenaire { get; set; }
        public string TitrePub { get; set; }
        public string DescriptionPub { get; set; }
        public string Image { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int NbVues { get; set; }
    }
}
