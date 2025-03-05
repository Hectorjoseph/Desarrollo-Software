using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Core.Entities
{
    public class Ruta
    {
        [Key]
        public int IdRuta { get; set; }

        [Required(ErrorMessage = "El origen es obligatorio")]
        [MaxLength(100, ErrorMessage = "El origen no puede exceder los 100 caracteres")]
        public string Origen { get; set; }

        [Required(ErrorMessage = "El destino es obligatorio")]
        [MaxLength(100, ErrorMessage = "El destino no puede exceder los 100 caracteres")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "La distancia es obligatoria")]
        public double Distancia { get; set; }

        [Required(ErrorMessage = "El tiempo estimado es obligatorio")]
        public double TiempoEstimado { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        // Relaciones con otras entidades
        public ICollection<PuntoRuta> PuntosRuta { get; set; } = new List<PuntoRuta>();
    }
}