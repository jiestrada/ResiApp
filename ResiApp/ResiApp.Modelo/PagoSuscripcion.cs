using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResiApp.Models
{
    /// <summary>
    /// Pagos realizados para las suscripciones.
    /// </summary>
    [Table("pagos_suscripcion")]
    public class PagoSuscripcion
    {
        [Key]
        [Column("pago_suscripcion_id")]
        public int PagoSuscripcionId { get; set; }

        /// <summary>
        /// ID de la suscripción a la que corresponde el pago.
        /// </summary>
        [Required]
        [Column("suscripcion_id")]
        public int SuscripcionId { get; set; }

        /// <summary>
        /// Monto del pago realizado.
        /// </summary>
        [Required]
        [Column("monto", TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        /// <summary>
        /// Fecha en que se realizó el pago.
        /// </summary>
        [Required]
        [Column("fecha_pago")]
        public DateTime FechaPago { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Estado del pago (ejemplo: completado, fallido).
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("estado")]
        public string Estado { get; set; }

        /// <summary>
        /// ID de la transacción en Openpay.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("openpay_transaccion_id")]
        public string OpenpayTransaccionId { get; set; }

        // Propiedades de navegación
        [ForeignKey("SuscripcionId")]
        public Suscripcion Suscripcion { get; set; }
    }
}
