using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Control de acceso a documentos; define qué usuarios tienen permisos para acceder a cada documento.
    /// </summary>
    [Table("documentos_permisos")]
    public class DocumentoPermiso
    {
        [Key]
        [Column("documento_permiso_id")]
        public int DocumentoPermisoId { get; set; }

        [Required]
        [Column("documento_id")]
        public int DocumentoId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        // Propiedades de navegación
        [ForeignKey("DocumentoId")]
        public Documento Documento { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
