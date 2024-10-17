using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Detalles específicos de los pagos realizados en línea.
    /// </summary>
    [Table("pagos_en_linea")]
    public class PagoEnLinea
    {
        [Key]
        [Column("pago_en_linea_id")]
        public int PagoEnLineaId { get; set; }

        [Required]
        [Column("pago_id")]
        public int PagoId { get; set; }

        /// <summary>
        /// Identificador de la transacción proporcionado por el proveedor.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("transaccion_id")]
        public string TransaccionId { get; set; }

        /// <summary>
        /// Nombre del proveedor del servicio de pago en línea.
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("proveedor")]
        public string Proveedor { get; set; }

        /// <summary>
        /// Estado de la transacción en el proveedor.
        /// </summary>
        [StringLength(50)]
        [Column("estado_transaccion")]
        public string EstadoTransaccion { get; set; }

        /// <summary>
        /// Fecha y hora de la transacción en línea.
        /// </summary>
        [Column("fecha_transaccion")]
        public DateTime FechaTransaccion { get; set; } = DateTime.Now;

        // Propiedades de navegación
        [ForeignKey("PagoId")]
        public Pago Pago { get; set; }
    }
}
