using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Almacena la información básica de todos los usuarios registrados en la plataforma.
    /// </summary>
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del usuario.
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("apellido")]
        public string Apellido { get; set; }

        /// <summary>
        /// Correo electrónico único del usuario.
        /// </summary>
        [Required]
        [StringLength(100)]
        [EmailAddress]
        [Column("correo_electronico")]
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// Contraseña encriptada del usuario.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("contrasena")]
        public string Contrasena { get; set; }

        /// <summary>
        /// Número de teléfono de contacto del usuario.
        /// </summary>
        [StringLength(20)]
        [Column("telefono")]
        public string Telefono { get; set; }

        /// <summary>
        /// Indica si el usuario está activo en la plataforma.
        /// </summary>
        [Column("activo")]
        public bool Activo { get; set; } = true;

        /// <summary>
        /// Fecha y hora de creación del registro del usuario.
        /// </summary>
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Propiedades de navegación
        public ICollection<UsuarioRol> UsuariosRoles { get; set; }
        public ICollection<ResidenteUnidad> ResidentesUnidades { get; set; }
        public ICollection<Notificacion> Notificaciones { get; set; }
        public ICollection<Mensaje> MensajesEnviados { get; set; }
        public ICollection<Mensaje> MensajesRecibidos { get; set; }
        public ICollection<TicketSoporte> TicketsSoporte { get; set; }
        public ICollection<RespuestaSoporte> RespuestasSoporte { get; set; }
        public ICollection<PreferenciaUsuario> PreferenciasUsuario { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
