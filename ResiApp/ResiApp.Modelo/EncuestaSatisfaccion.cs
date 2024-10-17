using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Encuestas enviadas a los usuarios para evaluar la satisfacción.
    /// </summary>
    [Table("encuestas_satisfaccion")]
    public class EncuestaSatisfaccion
    {
        [Key]
        [Column("encuesta_satisfaccion_id")]
        public int EncuestaSatisfaccionId { get; set; }

        /// <summary>
        /// Título de la encuesta de satisfacción.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descripción de la encuesta de satisfacción.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha en que se envió la encuesta.
        /// </summary>
        [Required]
        [Column("fecha_envio")]
        public DateTime FechaEnvio { get; set; }

        // Propiedades de navegación
        public ICollection<RespuestaEncuestaSatisfaccion> RespuestasEncuestaSatisfaccion { get; set; }
    }
}

