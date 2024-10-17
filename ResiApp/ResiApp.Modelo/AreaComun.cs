using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Áreas comunes disponibles para reserva.
    /// </summary>
    [Table("areas_comunes")]
    public class AreaComun
    {
        [Key]
        [Column("area_comun_id")]
        public int AreaComunId { get; set; }

        [Required]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        /// <summary>
        /// Nombre del área común.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada del área común.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Capacidad máxima del área común.
        /// </summary>
        [Column("capacidad")]
        public int? Capacidad { get; set; }

        /// <summary>
        /// Ubicación física del área común dentro del condominio.
        /// </summary>
        [StringLength(255)]
        [Column("ubicacion")]
        public string Ubicacion { get; set; }

        /// <summary>
        /// Indica si el área común está disponible para reservas.
        /// </summary>
        [Column("disponible")]
        public bool Disponible { get; set; } = true;

        // Propiedades de navegación
        [ForeignKey("CondominioId")]
        public Condominio Condominio { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}

