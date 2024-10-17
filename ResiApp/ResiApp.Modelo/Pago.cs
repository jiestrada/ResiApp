using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Pagos realizados por los residentes.
    /// </summary>
    [Table("pagos")]
    public class Pago
    {
        [Key]
        [Column("pago_id")]
        public int PagoId { get; set; }

        [Required]
        [Column("factura_id")]
        public int FacturaId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Monto del pago realizado.
        /// </summary>
        [Required]
        [Column("monto", TypeName = "decimal(12,2)")]
        public decimal Monto { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó el pago.
        /// </summary>
        [Column("fecha_pago")]
        public DateTime FechaPago { get; set; } = DateTime.Now;

        [Required]
        [Column("metodo_pago_id")]
        public int MetodoPagoId { get; set; }

        /// <summary>
        /// Referencia o código del pago.
        /// </summary>
        [StringLength(100)]
        [Column("referencia")]
        public string Referencia { get; set; }

        /// <summary>
        /// Estado actual del pago.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "pendiente";

        // Propiedades de navegación
        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("MetodoPagoId")]
        public MetodoPago MetodoPago { get; set; }

        public PagoEnLinea PagoEnLinea { get; set; }
    }
}
