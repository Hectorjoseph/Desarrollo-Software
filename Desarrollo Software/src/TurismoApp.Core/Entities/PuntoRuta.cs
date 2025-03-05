using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurismoApp.Core.Entities
{
    public class PuntoRuta
    {
        [Key]
        public int IdPuntoRuta { get; set; }

        [Required(ErrorMessage = "El orden del punto en la ruta es obligatorio")]
        public int Orden { get; set; }

        [ForeignKey(nameof(Lugar))]
        public int IdLugar { get; set; }

        public Lugar Lugar { get; set; }

        [ForeignKey(nameof(Ruta))]
        public int IdRuta { get; set; }

        public Ruta Ruta { get; set; }
    }
}