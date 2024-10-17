using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Tabla de unión que asigna permisos a roles.
    /// </summary>
    [Table("roles_permisos")]
    public class RolPermiso
    {
        [Key]
        [Column("rol_permiso_id")]
        public int RolPermisoId { get; set; }

        [Required]
        [Column("rol_id")]
        public int RolId { get; set; }

        [Required]
        [Column("permiso_id")]
        public int PermisoId { get; set; }

        // Propiedades de navegación
        [ForeignKey("RolId")]
        public Rol Rol { get; set; }

        [ForeignKey("PermisoId")]
        public Permiso Permiso { get; set; }
    }
}
