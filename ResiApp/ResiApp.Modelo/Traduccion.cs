using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Almacena textos traducidos para soportar múltiples idiomas.
    /// </summary>
    [Table("traducciones")]
    public class Traduccion
    {
        [Key]
        [Column("traduccion_id")]
        public int TraduccionId { get; set; }

        /// <summary>
        /// Clave única del texto a traducir.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("clave")]
        public string Clave { get; set; }

        [Required]
        [Column("idioma_id")]
        public int IdiomaId { get; set; }

        /// <summary>
        /// Texto traducido en el idioma correspondiente.
        /// </summary>
        [Required]
        [Column("texto")]
        public string Texto { get; set; }

        // Propiedades de navegación
        [ForeignKey("IdiomaId")]
        public Idioma Idioma { get; set; }
    }
}
