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
    /// Tipos de suscripciones disponibles en la plataforma.
    /// </summary>
    [Table("tipos_suscripcion")]
    public class TipoSuscripcion
    {
        [Key]
        [Column("tipo_suscripcion_id")]
        public int TipoSuscripcionId { get; set; }

        /// <summary>
        /// Nombre del plan de suscripción.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción del plan de suscripción.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Precio mensual del plan.
        /// </summary>
        [Required]
        [Column("precio_mensual", TypeName = "decimal(18,2)")]
        public decimal PrecioMensual { get; set; }

        /// <summary>
        /// Precio anual del plan.
        /// </summary>
        [Required]
        [Column("precio_anual", TypeName = "decimal(18,2)")]
        public decimal PrecioAnual { get; set; }

        /// <summary>
        /// Número máximo de unidades permitidas en este plan.
        /// </summary>
        [Required]
        [Column("max_unidades")]
        public int MaxUnidades { get; set; }

        /// <summary>
        /// ID del plan en Openpay mensual.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("openpay_plan_mensual_id")]
        public string OpenpayPlanMensualId { get; set; }


        /// <summary>
        /// ID del plan en Openpay anual.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("openpay_plan_anual_id")]
        public string OpenpayPlanAnualId { get; set; }

        /// <summary>
        /// Indica si el plan está activo y disponible.
        /// </summary>
        [Column("activo")]
        public bool Activo { get; set; } = true;

        // Propiedades de navegación
        public ICollection<Suscripcion> Suscripciones { get; set; }
    }
}
