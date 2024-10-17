using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Foros de discusión dentro del condominio.
    /// </summary>
    [Table("foros")]
    public class Foro
    {
        [Key]
        [Column("foro_id")]
        public int ForoId { get; set; }

        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        /// <summary>
        /// Título del foro.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descripción del foro.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha y hora de creación del foro.
        /// </summary>
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Propiedades de navegación
        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }

        public ICollection<Tema> Temas { get; set; }
    }
}
