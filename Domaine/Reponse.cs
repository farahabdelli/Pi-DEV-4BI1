using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Reponse
    {
        public int ReponseId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DatePost { get; set; }
        public int NbVues { get; set; }
        public int NbLikes { get; set; }
        public int NbDislikes { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Categorie Categorie { get; set; }
        // [ForeignKey("Categorie")]
        public int? QuestionId { get; set; }
    }
}
