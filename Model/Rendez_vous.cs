using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model
{ 
    public class Rendez_vous /// constlatation ou vissite 
    {

        public int Id { get; set; }
       
      
        public DateTime Date { get; set; }
        public int Medcineid { get; set; }
        public int Patientid { get; set; }

        public string UserId { get; set; }
        public virtual Medcine Medcine { get; set; }

        public virtual Patient Patient { get; set; }



        public virtual ApplicationUser user { get; set; }

    }
}
