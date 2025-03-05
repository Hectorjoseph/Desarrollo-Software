using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurismoApp.Core.Entities
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }

        [Required(ErrorMessage = "El texto del comentario es obligatorio")]
        [MaxLength(500, ErrorMessage = "El comentario no puede exceder los 500 caracteres")]
        public string Texto { get; set; }

        public double? Calificacion { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [ForeignKey(nameof(Lugar))]
        public int IdLugar { get; set; }

        public Lugar Lugar { get; set; }
    }
}