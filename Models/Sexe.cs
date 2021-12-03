using System.Collections.Generic;

namespace Model
{
    public class Sexe
    {
        public int id { get; set; }
        public string nom { get; set; }
        public ICollection<Medcine> Medcines { get; set; }
    }
}