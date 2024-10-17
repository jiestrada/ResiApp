using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Respuestas del equipo de soporte a los tickets.
    /// </summary>
    [Table("respuestas_soporte")]
    public class RespuestaSoporte
    {
        [Key]
        [Column("respuesta_id")]
        public int RespuestaId { get; set; }

        [Required]
        [Column("ticket_id")]
        public int TicketId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Contenido de la respuesta.
        /// </summary>
        [Required]
        [Column("contenido")]
        public string Contenido { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó la respuesta.
        /// </summary>
        [Column("fecha_respuesta")]
        public DateTime FechaRespuesta { get; set; } = DateTime.Now;

        // Propiedades de navegación
        [ForeignKey("TicketId")]
        public TicketSoporte TicketSoporte { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
