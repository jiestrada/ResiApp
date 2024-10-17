
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Asocia residentes a unidades.
    /// </summary>
    [Table("residentes_unidades")]
    public class ResidenteUnidad
    {
        [Key]
        [Column("residente_unidad_id")]
        public int ResidenteUnidadId { get; set; }

        [Required]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Required]
        [Column("unidad_id")]
        public int UnidadId { get; set; }

        /// <summary>
        /// Fecha de inicio de la residencia.
        /// </summary>
        [Required]
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha de fin de la residencia (opcional).
        /// </summary>
        [Column("fecha_fin")]
        public DateTime? FechaFin { get; set; }

        // Propiedades de navegación
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("UnidadId")]
        public Unidad Unidad { get; set; }

        public ICollection<Factura> Facturas { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Incidencia> Incidencias { get; set; }
    }
}

