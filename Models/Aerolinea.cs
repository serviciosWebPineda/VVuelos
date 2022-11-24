
using System.ComponentModel.DataAnnotations;

namespace V_Vuelo.Models
{
    public class Aerolinea
    {
        [Key]
        public string Aerolinea_id { get; set; }
        public string Nombre_aerolinea { get; set; }
    }
}
