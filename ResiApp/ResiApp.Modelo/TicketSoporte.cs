using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Tickets creados por los usuarios para reportar problemas técnicos o solicitar ayuda.
    /// </summary>
    [Table("tickets_soporte")]
    public class TicketSoporte
    {
        [Key]
        [Column("ticket_id")]
        public int TicketId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Asunto del ticket.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("asunto")]
        public string Asunto { get; set; }

        /// <summary>
        /// Descripción detallada del problema o solicitud.
        /// </summary>
        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha y hora de creación del ticket.
        /// </summary>
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        /// <summary>
        /// Estado actual del ticket.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "abierto";

        /// <summary>
        /// Fecha y hora en que se cerró el ticket.
        /// </summary>
        [Column("fecha_cierre")]
        public DateTime? FechaCierre { get; set; }

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public ICollection<RespuestaSoporte> RespuestasSoporte { get; set; }
    }
}
