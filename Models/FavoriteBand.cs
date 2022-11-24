﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace V_Vuelo.Models
{
    public class FavoriteBand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnteredBy { get; set; }
        public DateTime EnteredOn { get; set; }
    }
}
