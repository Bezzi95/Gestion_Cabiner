﻿using System.Collections.Generic;

namespace Model
{
    public class Ville
    {
        public int id { get; set; }
        public string nom { get; set; }
        public ICollection<Medcine> Medcines { get; set; }
    }
}