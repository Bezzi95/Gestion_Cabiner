using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinetWebAPI.Model
{ 
    public class Rendez_vous 
    {

        public int Id { get; set; }
        public DateTime Date_rendez_vous { get; set; }
        public String Status { get; set; }
        public int Medcineid { get; set; }
        public Medcine Medcine { get; set; }
        public int Patientid { get; set; }
        public  Patient Patient { get; set; }
        public virtual ApplicationUser user { get; set; }
        public string UserId { get; set; }


    }
}
