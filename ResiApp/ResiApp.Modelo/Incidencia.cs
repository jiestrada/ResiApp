using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Incidencias o solicitudes de mantenimiento reportadas.
    /// </summary>
    [Table("incidencias")]
    public class Incidencia
    {
        [Key]
        [Column("incidencia_id")]
        public int IncidenciaId { get; set; }

        [Required]
        [Column("residente_unidad_id")]
        public int ResidenteUnidadId { get; set; }

        /// <summary>
        /// Título breve de la incidencia.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descripción detallada de la incidencia.
        /// </summary>
        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha y hora en que se reportó la incidencia.
        /// </summary>
        [Column("fecha_reporte")]
        public DateTime FechaReporte { get; set; } = DateTime.Now;

        /// <summary>
        /// Estado actual de la incidencia.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "abierta";

        /// <summary>
        /// Nivel de prioridad de la incidencia.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("prioridad")]
        public string Prioridad { get; set; } = "media";

        /// <summary>
        /// Fecha y hora en que se resolvió la incidencia.
        /// </summary>
        [Column("fecha_resolucion")]
        public DateTime? FechaResolucion { get; set; }

        /// <summary>
        /// Comentarios adicionales sobre la incidencia.
        /// </summary>
        [Column("comentarios")]
        public string Comentarios { get; set; }

        // Propiedades de navegación
        [ForeignKey("ResidenteUnidadId")]
        public ResidenteUnidad ResidenteUnidad { get; set; }

        public ICollection<IncidenciaAsignacion> IncidenciasAsignaciones { get; set; }
    }
}
