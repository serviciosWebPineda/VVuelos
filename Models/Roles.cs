using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace V_Vuelo.Models
{
    public class Roles
    {
        [Key]
        public string Rol_id { get; set; }
        public string Rol { get; set; }
        public string Descripcion { get; set; }
    }
}
