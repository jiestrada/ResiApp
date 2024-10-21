
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{   

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

        // Nuevo campo para el condominio
        [Column("condominio_id")]
        public int? CondominioId { get; set; }  // Puede ser null para roles globales

        [Column("activo")]
        public bool Activo { get; set; }=false;

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("RolId")]
        public Rol Rol { get; set; }

        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }
    }

}
