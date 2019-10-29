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
        [Key]
        public int ProduitId { get; set; }
        [Required(ErrorMessage = "Entrer le nom de produit")]
        [StringLength(25, ErrorMessage = "nom ne doit pas dépasser 25")]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Nom { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Networks { get; set; }
        public string Image { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public Double Prix { get; set; }
        [Range(0, int.MaxValue)]
        [Display(Name = "Quantity")]
        public int Quantite { get; set; }

        [Display(Name = "Category")]
        // [ForeignKey("Categorie")]
        public int? CategorieId { get; set; }
        // [ForeignKey("Categorie")]
        [Display(Name = "Brand")]
        public int? BrandId { get; set; }
        // [ForeignKey("Categorie")]
        [Display(Name = "Network")]
        public int? NetworkId { get; set; }




    }
}