
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Documentos importantes del condominio.
    /// </summary>
    [Table("documentos")]
    public class Documento
    {
        [Key]
        [Column("documento_id")]
        public int DocumentoId { get; set; }

        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        [Required]
        [Column("administrador_id")]
        public int AdministradorId { get; set; }

        /// <summary>
        /// Título del documento.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descripción detallada del documento.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Ruta o nombre del archivo almacenado.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("ruta_archivo")]
        public string RutaArchivo { get; set; }

        /// <summary>
        /// Fecha y hora en que se subió el documento.
        /// </summary>
        [Column("fecha_subida")]
        public DateTime FechaSubida { get; set; } = DateTime.Now;

        /// <summary>
        /// Tipo o categoría del documento.
        /// </summary>
        [StringLength(50)]
        [Column("tipo")]
        public string Tipo { get; set; }

        // Propiedades de navegación
        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }

        [ForeignKey("AdministradorId")]
        public Usuario Administrador { get; set; }

        public ICollection<DocumentoPermiso> DocumentosPermisos { get; set; }
    }
}
