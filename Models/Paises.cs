
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace V_Vuelo.Models
{
    public class Paises
    {
        [Key]
        public string Pais_id { get; set; }
        public string Pais { get; set; }       
    }
}
