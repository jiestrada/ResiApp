using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Votos realizados por los residentes en las encuestas.
    /// </summary>
    [Table("votos_encuesta")]
    public class VotoEncuesta
    {
        [Key]
        [Column("voto_id")]
        public int VotoId { get; set; }

        [Required]
        [Column("encuesta_id")]
        public int EncuestaId { get; set; }

        [Required]
        [Column("opcion_id")]
        public int OpcionId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó el voto.
        /// </summary>
        [Column("fecha_voto")]
        public DateTime FechaVoto { get; set; } = DateTime.Now;

        // Propiedades de navegación
        [ForeignKey("EncuestaId")]
        public Encuesta Encuesta { get; set; }

        [ForeignKey("OpcionId")]
        public OpcionEncuesta OpcionEncuesta { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
