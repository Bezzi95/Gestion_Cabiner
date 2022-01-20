using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{ 


    public class Medcine
    {
        public int id { get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string prenom { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public string Telephone { get; set; }
        [DisplayName("Photo de profil")]
        public string photo { get; set; }

        public ICollection<Consultation> Consultations { get; set; }


        public Sexe Sexe { get; set; }
        public int Sexeid { get; set; }

        public Ville Ville { get; set; }
        public int Villeid { get; set; }

        public Specialite Specialite { get; set; }
        public int Specialiteid { get; set; }
    }
}
