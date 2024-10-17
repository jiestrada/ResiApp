using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Registro de actividades y eventos en el sistema.
    /// </summary>
    [Table("logs_actividad")]
    public class LogActividad
    {
        [Key]
        [Column("log_id")]
        public int LogId { get; set; }

        [Column("usuario_id")]
        public int? UsuarioId { get; set; }

        /// <summary>
        /// Nombre de la acción realizada.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("accion")]
        public string Accion { get; set; }

        /// <summary>
        /// Descripción detallada de la actividad.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha y hora en que ocurrió la actividad.
        /// </summary>
        [Column("fecha_hora")]
        public DateTime FechaHora { get; set; } = DateTime.Now;

        /// <summary>
        /// Dirección IP desde la cual se realizó la actividad.
        /// </summary>
        [StringLength(45)]
        [Column("direccion_ip")]
        public string DireccionIp { get; set; }

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
