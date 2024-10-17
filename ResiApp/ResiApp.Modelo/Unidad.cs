using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Representa las unidades habitacionales dentro de cada condominio.
    /// </summary>
    [Table("unidades")]
    public class Unidad
    {
        [Key]
        [Column("unidad_id")]
        public int UnidadId { get; set; }

        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        /// <summary>
        /// Número o identificador de la unidad.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("numero_unidad")]
        public string NumeroUnidad { get; set; }

        /// <summary>
        /// Tipo de unidad.
        /// </summary>
        [StringLength(50)]
        [Column("tipo_unidad")]
        public string TipoUnidad { get; set; }

        /// <summary>
        /// Descripción detallada de la unidad.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Área de la unidad en metros cuadrados.
        /// </summary>
        [Column("area_m2", TypeName = "decimal(10,2)")]
        public decimal? AreaM2 { get; set; }

        // Propiedades de navegación
        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }

        public ICollection<ResidenteUnidad> ResidentesUnidades { get; set; }
    }
}
