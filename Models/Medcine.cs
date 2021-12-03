using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Medcine
    {
        public int id { get; set; }
        
        public string nom { get; set; }
      
        public string prenom { get; set; }
        
        
        public string Email { get; set; }
       
        public string Adresse { get; set; }
        
        public string Telephone { get; set; }
        [DisplayName("Photo de profil")]
        public string photo { get; set; }
                   
        public ICollection<Consultation> Consultations { get; set; }
        

        public Sexe Sexe { get; set; }
        public int Sexeid { get; set; }

        public Ville Ville { get; set; }
        public int Villeid { get; set; }

        public virtual Specialite Specialite { get; set; }
        public int Specialiteid { get; set; }
    }
}
