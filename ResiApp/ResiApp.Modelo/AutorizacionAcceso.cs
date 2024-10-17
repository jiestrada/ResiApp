using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Autorizaciones de ingreso al condominio.
    /// </summary>
    [Table("autorizaciones_acceso")]
    public class AutorizacionAcceso
    {
        [Key]
        [Column("autorizacion_id")]
        public int AutorizacionId { get; set; }

        [Required]
        [Column("visitante_id")]
        public int VisitanteId { get; set; }

        /// <summary>
        /// Fecha y hora en que se autorizó el acceso.
        /// </summary>
        [Column("fecha_autorizacion")]
        public DateTime FechaAutorizacion { get; set; } = DateTime.Now;

        /// <summary>
        /// Estado actual de la autorización.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "pendiente";

        /// <summary>
        /// Comentarios adicionales sobre la autorización.
        /// </summary>
        [Column("comentarios")]
        public string Comentarios { get; set; }

        // Propiedades de navegación
        [ForeignKey("VisitanteId")]
        public Visitante Visitante { get; set; }
    }
}
