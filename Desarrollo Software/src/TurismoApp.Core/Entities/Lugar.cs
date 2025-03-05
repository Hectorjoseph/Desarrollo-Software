using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Core.Entities
{
    public class Lugar
    {
        [Key]
        public int IdLugar { get; set; }

        [Required(ErrorMessage = "El nombre del lugar es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre del lugar no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El tipo de lugar es obligatorio")]
        [MaxLength(50, ErrorMessage = "El tipo de lugar no puede exceder los 50 caracteres")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "La latitud es obligatoria")]
        public double Latitud { get; set; }

        [Required(ErrorMessage = "La longitud es obligatoria")]
        public double Longitud { get; set; }

        public double? Calificacion { get; set; }

        // Relaciones con otras entidades
        public ICollection<Clima> Climas { get; set; } = new List<Clima>();
        public ICollection<PuntoRuta> PuntosRuta { get; set; } = new List<PuntoRuta>();
        public ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}