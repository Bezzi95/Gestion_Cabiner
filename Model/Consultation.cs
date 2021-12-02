using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model
{
    public class Consultation
    {
        public int id { get; set; }
        [Required]
        public DateTime Date_Consult { get; set; }
        [Required]
        public string resultat { get; set; }
        public Patient Patient { get; set; }
        public int Patientid { get; set; }
        public Medcine Medecin { get; set; }
        public int Medecinid { get; set; }
       
        public virtual ApplicationUser user { get; set; }
        public string UserId { get; set; }

    }
}
