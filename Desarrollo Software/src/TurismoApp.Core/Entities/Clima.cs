using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurismoApp.Core.Entities
{
    public class Clima
    {
        [Key]
        public int IdClima { get; set; }

        [Required(ErrorMessage = "La temperatura es obligatoria")]
        public double Temperatura { get; set; }

        [Required(ErrorMessage = "La humedad es obligatoria")]
        public double Humedad { get; set; }

        [Required(ErrorMessage = "El estado del clima es obligatorio")]
        [MaxLength(50, ErrorMessage = "El estado del clima no puede exceder los 50 caracteres")]
        public string Estado { get; set; }

        [ForeignKey(nameof(Lugar))]
        public int IdLugar { get; set; }

        public Lugar Lugar { get; set; }
    }
}