using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Core.Dtos
{
    // DTO para creación de usuario
    public class UsuarioCreacionDto
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [MaxLength(30, ErrorMessage = "El nombre de usuario no puede exceder los 30 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [MaxLength(50, ErrorMessage = "El correo no puede exceder los 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; }

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
    }

    // DTO para lectura/retorno de usuario
    public class UsuarioDetalleDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? UltimaConexion { get; set; }
        public bool EstadoActivo { get; set; }
    }

    // DTO para actualización de usuario
    public class UsuarioActualizacionDto
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        public string? Telefono { get; set; }
    }
}