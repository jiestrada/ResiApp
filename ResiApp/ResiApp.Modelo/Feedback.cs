using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Feedback proporcionado por los usuarios sobre la plataforma.
    /// </summary>
    [Table("feedback")]
    public class Feedback
    {
        [Key]
        [Column("feedback_id")]
        public int FeedbackId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Tipo de feedback (e.g., Sugerencia, Reporte de error).
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("tipo")]
        public string Tipo { get; set; }

        /// <summary>
        /// Contenido detallado del feedback.
        /// </summary>
        [Required]
        [Column("contenido")]
        public string Contenido { get; set; }

        /// <summary>
        /// Fecha y hora en que se envió el feedback.
        /// </summary>
        [Column("fecha_envio")]
        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        /// <summary>
        /// Estado actual del feedback.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "nuevo";

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
