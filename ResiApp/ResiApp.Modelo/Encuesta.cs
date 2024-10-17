
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Encuestas creadas por los administradores.
    /// </summary>
    [Table("encuestas")]
    public class Encuesta
    {
        [Key]
        [Column("encuesta_id")]
        public int EncuestaId { get; set; }

        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        /// <summary>
        /// Título de la encuesta.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descripción de la encuesta.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha de inicio de la encuesta.
        /// </summary>
        [Required]
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha de fin de la encuesta.
        /// </summary>
        [Column("fecha_fin")]
        public DateTime? FechaFin { get; set; }

        // Propiedades de navegación
        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }

        public ICollection<OpcionEncuesta> OpcionesEncuesta { get; set; }
        public ICollection<VotoEncuesta> VotosEncuesta { get; set; }
    }
}
