using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace V_Vuelo.Models
{
    public class Consecutivos
    {
        [Key]
        public string Consecutivo_Id { get; set; }
        public string Consecutivo { get; set; }
        public string Descripcion { get; set; }
        public bool Disponibilidad_prefijo { get; set; }
        public string Prefijo { get; set; }
        public bool Rango { get; set; }
        public int Rango_inicial { get; set; }
        public int Rango_final { get; set; }
    }
}
