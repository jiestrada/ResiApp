using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Mensajes intercambiados entre usuarios.
    /// </summary>
    [Table("mensajes")]
    public class Mensaje
    {
        [Key]
        [Column("mensaje_id")]
        public int MensajeId { get; set; }

        [Required]
        [Column("remitente_id")]
        public int RemitenteId { get; set; }

        [Required]
        [Column("destinatario_id")]
        public int DestinatarioId { get; set; }

        /// <summary>
        /// Asunto del mensaje.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("asunto")]
        public string Asunto { get; set; }

        /// <summary>
        /// Contenido detallado del mensaje.
        /// </summary>
        [Required]
        [Column("contenido")]
        public string Contenido { get; set; }

        /// <summary>
        /// Fecha y hora en que se envió el mensaje.
        /// </summary>
        [Column("fecha_envio")]
        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        /// <summary>
        /// Indica si el destinatario ha leído el mensaje.
        /// </summary>
        [Column("leido")]
        public bool Leido { get; set; } = false;

        // Propiedades de navegación
        [ForeignKey("RemitenteId")]
        public Usuario Remitente { get; set; }

        [ForeignKey("DestinatarioId")]
        public Usuario Destinatario { get; set; }
    }
}
