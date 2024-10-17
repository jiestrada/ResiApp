using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Lista de idiomas soportados por la plataforma.
    /// </summary>
    [Table("idiomas")]
    public class Idioma
    {
        [Key]
        [Column("idioma_id")]
        public int IdiomaId { get; set; }

        /// <summary>
        /// Código del idioma.
        /// </summary>
        [Required]
        [StringLength(10)]
        [Column("codigo")]
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre del idioma.
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("nombre")]
        public string Nombre { get; set; }

        // Propiedades de navegación
        public ICollection<Traduccion> Traducciones { get; set; }
    }
}
