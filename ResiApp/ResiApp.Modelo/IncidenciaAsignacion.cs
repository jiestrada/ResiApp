using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Asignaciones de incidencias a personal de mantenimiento.
    /// </summary>
    [Table("incidencias_asignaciones")]
    public class IncidenciaAsignacion
    {
        [Key]
        [Column("incidencia_asignacion_id")]
        public int IncidenciaAsignacionId { get; set; }

        [Required]
        [Column("incidencia_id")]
        public int IncidenciaId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Fecha y hora en que se asignó la incidencia.
        /// </summary>
        [Column("fecha_asignacion")]
        public DateTime FechaAsignacion { get; set; } = DateTime.Now;

        // Propiedades de navegación
        [ForeignKey("IncidenciaId")]
        public Incidencia Incidencia { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
