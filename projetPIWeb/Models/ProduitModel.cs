using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetPIWeb.Models
{
    public class ProduitModel
    {
    
        [Required(ErrorMessage = "Entrer le nom de produit")]
        [StringLength(25, ErrorMessage = "nom ne doit pas dépasser 25")]
        [MaxLength(50)]
        public string Nom { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public Double Prix { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantite { get; set; }
        public string Image { get; set; }
      
        // [ForeignKey("Categorie")]
        public int? CategorieId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}