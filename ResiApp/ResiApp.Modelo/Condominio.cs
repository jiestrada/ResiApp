using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiApp.Models
{
    /// <summary>
    /// Almacena información de los diferentes condominios administrados.
    /// </summary>
    [Table("condominios")]
    public class Condominio
    {
        [Key]
        [Column("condominio_id")]
        public int CondominioId { get; set; }

        /// <summary>
        /// Nombre del condominio.
        /// </summary>
        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Dirección física del condominio.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("direccion")]
        public string Direccion { get; set; }

        /// <summary>
        /// Descripción general del condominio.
        /// </summary>
        [Column("descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha y hora de creación del registro del condominio.
        /// </summary>
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Propiedades de navegación
        public ICollection<Unidad> Unidades { get; set; }
        public ICollection<Gasto> Gastos { get; set; }
        public ICollection<Anuncio> Anuncios { get; set; }
        public ICollection<AreaComun> AreasComunes { get; set; }
        public ICollection<Foro> Foros { get; set; }
        public ICollection<Encuesta> Encuestas { get; set; }
        public ICollection<Documento> Documentos { get; set; }
        public ICollection<ConfiguracionCondominio> ConfiguracionesCondominio { get; set; }
    }
}
