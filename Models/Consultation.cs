using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Consultation
    {
        public int id { get; set; }
       
        public DateTime Date_Consult { get; set; }
       
        public string resultat { get; set; }
        public Patient Patient { get; set; }
        public int Patientid { get; set; }
        public Medcine Medecin { get; set; }
        public int Medecinid { get; set; }
        
    }
}
