using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Facturas generadas para los residentes.
    /// </summary>
    [Table("facturas")]
    public class Factura
    {
        [Key]
        [Column("factura_id")]
        public int FacturaId { get; set; }

        [Required]
        [Column("residente_unidad_id")]
        public int ResidenteUnidadId { get; set; }

        /// <summary>
        /// Monto total de la factura.
        /// </summary>
        [Required]
        [Column("monto_total", TypeName = "decimal(12,2)")]
        public decimal MontoTotal { get; set; }

        /// <summary>
        /// Fecha de emisión de la factura.
        /// </summary>
        [Required]
        [Column("fecha_emision")]
        public DateTime FechaEmision { get; set; }

        /// <summary>
        /// Fecha de vencimiento de la factura.
        /// </summary>
        [Required]
        [Column("fecha_vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Estado actual de la factura.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "pendiente";

        /// <summary>
        /// Descripción o notas adicionales de la factura.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        // Propiedades de navegación
        [ForeignKey("ResidenteUnidadId")]
        public ResidenteUnidad ResidenteUnidad { get; set; }

        public ICollection<DetalleFactura> DetallesFacturas { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}

