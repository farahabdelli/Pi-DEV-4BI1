using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DatePost { get; set; }
        public int NbVues { get; set; }
        public int NbLikes { get; set; }
        public int NbDislikes { get; set; }
    }
}
