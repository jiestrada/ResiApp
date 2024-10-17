
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Tabla de unión para asignar múltiples roles a los usuarios.
    /// </summary>
    [Table("usuarios_roles")]
    public class UsuarioRol
    {
        [Key]
        [Column("usuario_rol_id")]
        public int UsuarioRolId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Required]
        [Column("rol_id")]
        public int RolId { get; set; }

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("RolId")]
        public Rol Rol { get; set; }
    }
}
