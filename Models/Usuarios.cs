using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace V_Vuelo.Models
{
    public class Usuarios
    {
        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }

        public string Rol_id { get; set; }
    }
}
 