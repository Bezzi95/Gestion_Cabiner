using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CabinetWebAPI.Model
{
    public class Patient
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

        public DateTime Date_naiss { get; set; }

        

        public ICollection<Consultation> Consultations { get; set; }
        public ICollection<Rendez_vous> Rendez_vouss { get; set; }


    }
}
