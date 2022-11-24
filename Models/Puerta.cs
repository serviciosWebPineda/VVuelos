using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace V_Vuelo.Models
{
    public class Puerta
    {
        [Key]
        public string Puerta_id { get; set; }
        public string Detalle { get; set; }
        public Boolean Estado_puerta { get; set; }
    }
}
