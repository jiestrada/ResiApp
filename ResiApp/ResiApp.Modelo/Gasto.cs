using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Registra los gastos comunes del condominio.
    /// </summary>
    [Table("gastos")]
    public class Gasto
    {
        [Key]
        [Column("gasto_id")]
        public int GastoId { get; set; }

        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        [Column("categoria_gasto_id")]
        public int? CategoriaGastoId { get; set; }

        /// <summary>
        /// Monto del gasto.
        /// </summary>
        [Required]
        [Column("monto", TypeName = "decimal(12,2)")]
        public decimal Monto { get; set; }

        /// <summary>
        /// Descripción detallada del gasto.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha en que se realizó el gasto.
        /// </summary>
        [Required]
        [Column("fecha_gasto")]
        public DateTime FechaGasto { get; set; }

        // Propiedades de navegación
        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }

        [ForeignKey("CategoriaGastoId")]
        public CategoriaGasto CategoriaGasto { get; set; }
    }
}
