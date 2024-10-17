using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Configuraciones específicas para cada condominio.
    /// </summary>
    [Table("configuraciones_condominio")]
    public class ConfiguracionCondominio
    {
        [Key]
        [Column("configuracion_id")]
        public int ConfiguracionId { get; set; }

        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        /// <summary>
        /// Nombre del parámetro de configuración.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("parametro")]
        public string Parametro { get; set; }

        /// <summary>
        /// Valor asignado al parámetro de configuración.
        /// </summary>
        [Required]
        [Column("valor")]
        public string Valor { get; set; }

        // Propiedades de navegación
        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }
    }
}
