using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurismoApp.Core.Entities
{
    public class HistorialBusqueda
    {
        [Key]
        public int IdHistorialBusqueda { get; set; }

        [Required(ErrorMessage = "La fecha de búsqueda es obligatoria")]
        [Display(Name = "Fecha de búsqueda")]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "La búsqueda realizada es obligatoria")]
        [MaxLength(200, ErrorMessage = "La búsqueda no puede exceder los 200 caracteres")]
        public string BusquedaRealizada { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}