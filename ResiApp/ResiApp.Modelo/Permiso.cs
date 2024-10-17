using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Define los permisos específicos que pueden ser asignados a roles.
    /// </summary>
    [Table("permisos")]
    public class Permiso
    {
        [Key]
        [Column("permiso_id")]
        public int PermisoId { get; set; }

        /// <summary>
        /// Nombre del permiso.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada del permiso.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        // Propiedades de navegación
        public ICollection<RolPermiso> RolesPermisos { get; set; }
    }
}

