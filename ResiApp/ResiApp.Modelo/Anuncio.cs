using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Anuncios publicados por los administradores.
    /// </summary>
    [Table("anuncios")]
    public class Anuncio
    {
        [Key]
        [Column("anuncio_id")]
        public int AnuncioId { get; set; }

        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        [Required]
        [Column("administrador_id")]
        public int AdministradorId { get; set; }

        /// <summary>
        /// Título del anuncio.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Contenido detallado del anuncio.
        /// </summary>
        [Required]
        [Column("contenido")]
        public string Contenido { get; set; }

        /// <summary>
        /// Fecha y hora en que se publicó el anuncio.
        /// </summary>
        [Column("fecha_publicacion")]
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;

        /// <summary>
        /// Fecha y hora en que expira el anuncio (opcional).
        /// </summary>
        [Column("fecha_expiracion")]
        public DateTime? FechaExpiracion { get; set; }

        /// <summary>
        /// Indica si el anuncio está activo o ha sido desactivado.
        /// </summary>
        [Column("activo")]
        public bool Activo { get; set; } = true;

        // Propiedades de navegación
        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }

        [ForeignKey("AdministradorId")]
        public Usuario Administrador { get; set; }
    }
}
