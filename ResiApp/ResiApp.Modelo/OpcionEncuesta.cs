using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Opciones disponibles en una encuesta.
    /// </summary>
    [Table("opciones_encuesta")]
    public class OpcionEncuesta
    {
        [Key]
        [Column("opcion_id")]
        public int OpcionId { get; set; }

        [Required]
        [Column("encuesta_id")]
        public int EncuestaId { get; set; }

        /// <summary>
        /// Descripción de la opción de encuesta.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        // Propiedades de navegación
        [ForeignKey("EncuestaId")]
        public Encuesta Encuesta { get; set; }

        public ICollection<VotoEncuesta> VotosEncuesta { get; set; }
    }
}
