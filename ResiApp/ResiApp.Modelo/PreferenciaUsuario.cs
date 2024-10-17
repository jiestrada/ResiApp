using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Preferencias individuales de los usuarios.
    /// </summary>
    [Table("preferencias_usuario")]
    public class PreferenciaUsuario
    {
        [Key]
        [Column("preferencia_id")]
        public int PreferenciaId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nombre del parámetro de preferencia.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("parametro")]
        public string Parametro { get; set; }

        /// <summary>
        /// Valor asignado al parámetro de preferencia.
        /// </summary>
        [Required]
        [Column("valor")]
        public string Valor { get; set; }

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
