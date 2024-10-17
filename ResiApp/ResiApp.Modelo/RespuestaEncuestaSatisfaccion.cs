using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Respuestas de los usuarios a las encuestas de satisfacción.
    /// </summary>
    [Table("respuestas_encuestas_satisfaccion")]
    public class RespuestaEncuestaSatisfaccion
    {
        [Key]
        [Column("respuesta_encuesta_id")]
        public int RespuestaEncuestaId { get; set; }

        [Required]
        [Column("encuesta_satisfaccion_id")]
        public int EncuestaSatisfaccionId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Calificación otorgada por el usuario (escala de 1 a 5).
        /// </summary>
        [Required]
        [Column("calificacion")]
        [Range(1, 5)]
        public int Calificacion { get; set; }

        /// <summary>
        /// Comentarios adicionales proporcionados por el usuario.
        /// </summary>
        [Column("comentarios")]
        public string Comentarios { get; set; }

        /// <summary>
        /// Fecha y hora en que se respondió la encuesta.
        /// </summary>
        [Column("fecha_respuesta")]
        public DateTime FechaRespuesta { get; set; } = DateTime.Now;

        // Propiedades de navegación
        [ForeignKey("EncuestaSatisfaccionId")]
        public EncuestaSatisfaccion EncuestaSatisfaccion { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
