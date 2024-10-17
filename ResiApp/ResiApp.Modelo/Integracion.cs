using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;
namespace ResiApp.Models
{
    /// <summary>
    /// Información sobre servicios externos integrados con la plataforma.
    /// </summary>
    [Table("integraciones")]
    public class Integracion
    {
        [Key]
        [Column("integracion_id")]
        public int IntegracionId { get; set; }

        /// <summary>
        /// Nombre del servicio externo.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("nombre_servicio")]
        public string NombreServicio { get; set; }

        /// <summary>
        /// Tipo de servicio.
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("tipo_servicio")]
        public string TipoServicio { get; set; }

        /// <summary>
        /// Detalles de configuración en formato JSON.
        /// </summary>
        [Required]
        [Column("detalles_configuracion", TypeName = "jsonb")]
        public JObject DetallesConfiguracion { get; set; }

        // Propiedades de navegación
        public ICollection<LogIntegracion> LogsIntegraciones { get; set; }
    }
}
