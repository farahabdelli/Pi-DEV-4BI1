﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Store
    {
        [Key]
        public int BoutiqueId { get; set; }
        [Required(ErrorMessage = "Entrer le nom de produit")]
        [StringLength(25, ErrorMessage = "nom ne doit pas dépasser 25")]
        [MaxLength(50)]
        [Display(Name = "Store")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Entrer la ville  du boutique")]
        [StringLength(25, ErrorMessage = "ville ne doit pas dépasser 25")]
        [MaxLength(50)]
        [Display(Name = "City")]
        public string Ville { get; set; }
        [Required(ErrorMessage = "Entrer l'adresse du boutique")]
        [StringLength(50, ErrorMessage = "adresse ne doit pas dépasser 50")]
        [MaxLength(50)]
        [Display(Name = "Address")]
        public string Adresse { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public int tel { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
        [Display(Name = "Opens at")]
        public string heure_ouv { get; set; }
        [Display(Name = "Closes at")]
        public string heure_ferm { get; set; }

        public virtual ICollection<ProductStore> ProductStores { get; set; }
        //  public virtual ICollection<Product> Produits { get; set; }
    }
}

/*-type :boutique,point de vente,smart store
service:ou payer ma facture, ou s achetent
les produits, besoin SAV*/