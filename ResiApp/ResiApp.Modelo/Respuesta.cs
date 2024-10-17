using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Respuestas a los temas en los foros.
    /// </summary>
    [Table("respuestas")]
    public class Respuesta
    {
        [Key]
        [Column("respuesta_id")]
        public int RespuestaId { get; set; }

        [Required]
        [Column("tema_id")]
        public int TemaId { get; set; }

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
        /// Fecha y hora de creación de la respuesta.
        /// </summary>
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Propiedades de navegación
        [ForeignKey("TemaId")]
        public Tema Tema { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
