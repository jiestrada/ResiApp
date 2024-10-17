using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Registro de transacciones y eventos con servicios externos.
    /// </summary>
    [Table("logs_integraciones")]
    public class LogIntegracion
    {
        [Key]
        [Column("log_integracion_id")]
        public int LogIntegracionId { get; set; }

        [Required]
        [Column("integracion_id")]
        public int IntegracionId { get; set; }

        /// <summary>
        /// Fecha y hora del evento.
        /// </summary>
        [Column("fecha_evento")]
        public DateTime FechaEvento { get; set; } = DateTime.Now;

        /// <summary>
        /// Tipo de evento registrado.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("tipo_evento")]
        public string TipoEvento { get; set; }

        /// <summary>
        /// Descripción del evento.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Respuesta recibida del servicio externo.
        /// </summary>
        [Column("respuesta_servicio")]
        public string RespuestaServicio { get; set; }

        // Propiedades de navegación
        [ForeignKey("IntegracionId")]
        public Integracion Integracion { get; set; }
    }
}
