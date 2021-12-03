using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class List
    {
        public Medcine Medcines { get; set; }
        public Patient Patients { get; set; }
        public ICollection<Sexe> Sexes { get; set; }
        public ICollection<Specialite> Specialites { get; set; }
        public ICollection<Ville>villes { get; set; }

    }
}
