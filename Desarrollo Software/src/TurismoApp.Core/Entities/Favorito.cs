using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurismoApp.Core.Entities
{
    public class Favorito
    {
        [Key]
        public int IdFavorito { get; set; }

        [Required(ErrorMessage = "La fecha de agregado es obligatoria")]
        [Display(Name = "Fecha de agregado")]
        public DateTime FechaAgregado { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [ForeignKey(nameof(Lugar))]
        public int IdLugar { get; set; }

        public Lugar Lugar { get; set; }
    }
}