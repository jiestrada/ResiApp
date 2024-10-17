using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Información de visitantes registrados por los residentes.
    /// </summary>
    [Table("visitantes")]
    public class Visitante
    {
        [Key]
        [Column("visitante_id")]
        public int VisitanteId { get; set; }

        [Required]
        [Column("residente_unidad_id")]
        public int ResidenteUnidadId { get; set; }

        /// <summary>
        /// Nombre completo del visitante.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Número de identificación del visitante.
        /// </summary>
        [StringLength(50)]
        [Column("identificacion")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Fecha programada de la visita.
        /// </summary>
        [Required]
        [Column("fecha_visita")]
        public DateTime FechaVisita { get; set; }

        /// <summary>
        /// Hora de entrada del visitante.
        /// </summary>
        [Column("hora_entrada")]
        public TimeSpan? HoraEntrada { get; set; }

        /// <summary>
        /// Hora de salida del visitante.
        /// </summary>
        [Column("hora_salida")]
        public TimeSpan? HoraSalida { get; set; }

        /// <summary>
        /// Indica si el visitante ha sido autorizado para ingresar.
        /// </summary>
        [Column("autorizado")]
        public bool Autorizado { get; set; } = false;

        // Propiedades de navegación
        [ForeignKey("ResidenteUnidadId")]
        public ResidenteUnidad ResidenteUnidad { get; set; }

        public ICollection<AutorizacionAcceso> AutorizacionesAcceso { get; set; }
    }
}
