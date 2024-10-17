using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Temas dentro de los foros.
    /// </summary>
    [Table("temas")]
    public class Tema
    {
        [Key]
        [Column("tema_id")]
        public int TemaId { get; set; }

        [Required]
        [Column("foro_id")]
        public int ForoId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Título del tema.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Contenido del tema.
        /// </summary>
        [Required]
        [Column("contenido")]
        public string Contenido { get; set; }

        /// <summary>
        /// Fecha y hora de creación del tema.
        /// </summary>
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        /// <summary>
        /// Fecha y hora de la última actualización del tema.
        /// </summary>
        [Column("fecha_actualizacion")]
        public DateTime? FechaActualizacion { get; set; }

        // Propiedades de navegación
        [ForeignKey("ForoId")]
        public Foro Foro { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public ICollection<Respuesta> Respuestas { get; set; }
    }
}
