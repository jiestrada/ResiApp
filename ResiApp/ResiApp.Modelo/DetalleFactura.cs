using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Detalles de cada factura, permitiendo desglose por conceptos.
    /// </summary>
    [Table("detalles_facturas")]
    public class DetalleFactura
    {
        [Key]
        [Column("detalle_factura_id")]
        public int DetalleFacturaId { get; set; }

        [Required]
        [Column("factura_id")]
        public int FacturaId { get; set; }

        /// <summary>
        /// Descripción del concepto facturado.
        /// </summary>
        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Monto del concepto en la factura.
        /// </summary>
        [Required]
        [Column("monto", TypeName = "decimal(12,2)")]
        public decimal Monto { get; set; }

        // Propiedades de navegación
        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; }
    }
}
