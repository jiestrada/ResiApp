
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Notificaciones enviadas a los usuarios.
    /// </summary>
    [Table("notificaciones")]
    public class Notificacion
    {
        [Key]
        [Column("notificacion_id")]
        public int NotificacionId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Título de la notificación.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Mensaje detallado de la notificación.
        /// </summary>
        [Required]
        [Column("mensaje")]
        public string Mensaje { get; set; }

        /// <summary>
        /// Fecha y hora en que se envió la notificación.
        /// </summary>
        [Column("fecha_envio")]
        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        /// <summary>
        /// Indica si el usuario ha leído la notificación.
        /// </summary>
        [Column("leido")]
        public bool Leido { get; set; } = false;

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
