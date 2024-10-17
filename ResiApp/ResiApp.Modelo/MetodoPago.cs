using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Métodos de pago disponibles.
    /// </summary>
    [Table("metodos_pago")]
    public class MetodoPago
    {
        [Key]
        [Column("metodo_pago_id")]
        public int MetodoPagoId { get; set; }

        /// <summary>
        /// Nombre del método de pago.
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada del método de pago.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        // Propiedades de navegación
        public ICollection<Pago> Pagos { get; set; }
    }
}
