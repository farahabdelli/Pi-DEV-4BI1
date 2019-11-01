using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Product
    {
        [Key]
        public int ProduitId { get; set; }
        [Required(ErrorMessage = "Entrer le nom de produit")]
        [StringLength(25, ErrorMessage = "nom ne doit pas dépasser 25")]
        [MaxLength(50)]
        [Display(Name = "Product")]
        public string Nom { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public Double Prix { get; set; }
        [Range(0, int.MaxValue)]
        [Display(Name = "Quantity")]
        public int Quantite { get; set; }
        public string Image { get; set; }
        [ForeignKey("CategorieId")]
        public virtual Category Categorie { get; set; }
        // [ForeignKey("Categorie")]
        [Display(Name = "Category")]
        public int? CategorieId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        // [ForeignKey("Brand")]
        [Display(Name = "Brand")]
        public int? BrandId { get; set; }
        [ForeignKey("NetworkId")]
        [Display(Name = "Network")]
        public virtual Network Network { get; set; }
        // [ForeignKey("Network")]
        public int? NetworkId { get; set; }

        public virtual ICollection<ProductStore> ProductStores { get; set; }



    }

}



