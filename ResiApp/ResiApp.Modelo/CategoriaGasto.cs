using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Categorías para clasificar los gastos.
    /// </summary>
    [Table("categorias_gastos")]
    public class CategoriaGasto
    {
        [Key]
        [Column("categoria_gasto_id")]
        public int CategoriaGastoId { get; set; }

        /// <summary>
        /// Nombre de la categoría de gasto.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada de la categoría.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        // Propiedades de navegación
        public ICollection<Gasto> Gastos { get; set; }
    }
}
