using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Define los diferentes roles que pueden existir en la plataforma.
    /// </summary>
    [Table("roles")]
    public class Rol
    {
        [Key]
        [Column("rol_id")]
        public int RolId { get; set; }

        /// <summary>
        /// Nombre del rol.
        /// </summary>
        [Required]
        [StringLength(50)]
        [Column("nombre")]
        public string Nombre { get; set; } = "";

        /// <summary>
        /// Descripción detallada del rol.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; } = "";

        [Column("mensaje")]
        public string Mensaje { get; set; } = "";

        // Propiedades de navegación
        public ICollection<UsuarioRol> UsuariosRoles { get; set; }
        public ICollection<RolPermiso> RolesPermisos { get; set; }
    }
}
