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
    /// Suscripciones de usuarios a planes de la plataforma.
    /// </summary>
    [Table("suscripciones")]
    public class Suscripcion
    {
        [Key]
        [Column("suscripcion_id")]
        public int SuscripcionId { get; set; }

        /// <summary>
        /// ID del usuario que está pagando la suscripción.
        /// </summary>
        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// ID del condominio al que se aplica la suscripción.
        /// </summary>
        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        /// <summary>
        /// ID del tipo de suscripción seleccionado.
        /// </summary>
        [Required]
        [Column("tipo_suscripcion_id")]
        public int TipoSuscripcionId { get; set; }

        /// <summary>
        /// ID del plan en Openpay.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("openpay_plan_id")]
        public string OpenpayPlanId { get; set; }

        /// <summary>
        /// ID de la suscripción en Openpay.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("openpay_suscripcion_id")]
        public string OpenpaySuscripcionId { get; set; }

        /// <summary>
        /// ID de la tarjeta en Openpay utilizada para los pagos.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("openpay_tarjeta_id")]
        public string OpenpayTarjetaId { get; set; }

        /// <summary>
        /// Fecha de inicio de la suscripción.
        /// </summary>
        [Required]
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indica si la suscripción está activa.
        /// </summary>
        [Column("activa")]
        public bool Activa { get; set; } = true;

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }

        [ForeignKey("TipoSuscripcionId")]
        public TipoSuscripcion TipoSuscripcion { get; set; }

        public ICollection<PagoSuscripcion> PagosSuscripcion { get; set; }
    }
}
