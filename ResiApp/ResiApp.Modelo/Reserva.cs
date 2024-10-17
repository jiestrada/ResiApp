using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Reservas realizadas por los residentes.
    /// </summary>
    [Table("reservas")]
    public class Reserva
    {
        [Key]
        [Column("reserva_id")]
        public int ReservaId { get; set; }

        [Required]
        [Column("area_comun_id")]
        public int AreaComunId { get; set; }

        [Required]
        [Column("residente_unidad_id")]
        public int ResidenteUnidadId { get; set; }

        /// <summary>
        /// Fecha en que se reserva el área común.
        /// </summary>
        [Required]
        [Column("fecha_reserva")]
        public DateTime FechaReserva { get; set; }

        /// <summary>
        /// Hora de inicio de la reserva.
        /// </summary>
        [Required]
        [Column("hora_inicio")]
        public TimeSpan HoraInicio { get; set; }

        /// <summary>
        /// Hora de fin de la reserva.
        /// </summary>
        [Required]
        [Column("hora_fin")]
        public TimeSpan HoraFin { get; set; }

        /// <summary>
        /// Estado actual de la reserva.
        /// </summary>
        [Required]
        [StringLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "pendiente";

        /// <summary>
        /// Comentarios o notas adicionales sobre la reserva.
        /// </summary>
        [Column("comentarios")]
        public string Comentarios { get; set; }

        // Propiedades de navegación
        [ForeignKey("AreaComunId")]
        public AreaComun AreaComun { get; set; }

        [ForeignKey("ResidenteUnidadId")]
        public ResidenteUnidad ResidenteUnidad { get; set; }
    }
}
