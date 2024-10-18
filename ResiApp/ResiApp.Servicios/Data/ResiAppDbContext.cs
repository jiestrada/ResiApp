using Microsoft.EntityFrameworkCore;
using ResiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResiApp.Services.Data
{
    public class ResiAppDbContext : DbContext
    {
        public ResiAppDbContext(DbContextOptions<ResiAppDbContext> options) : base(options)
        {
        }

        // Define un DbSet para cada modelo en ResiApp.Models
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<AreaComun> AreasComunes { get; set; }
        public DbSet<AutorizacionAcceso> AutorizacionesAcceso { get; set; }
        public DbSet<CategoriaGasto> CategoriasGasto { get; set; }
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<ConfiguracionCondominio> ConfiguracionesCondominio { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<DocumentoPermiso> DocumentosPermiso { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<EncuestaSatisfaccion> EncuestasSatisfaccion { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Foro> Foros { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<IncidenciaAsignacion> IncidenciasAsignacion { get; set; }
        public DbSet<Integracion> Integraciones { get; set; }
        public DbSet<LogActividad> LogsActividad { get; set; }
        public DbSet<LogIntegracion> LogsIntegracion { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<OpcionEncuesta> OpcionesEncuesta { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PagoEnLinea> PagosEnLinea { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<PreferenciaUsuario> PreferenciasUsuario { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ResidenteUnidad> ResidentesUnidad { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<RespuestaEncuestaSatisfaccion> RespuestasEncuestaSatisfaccion { get; set; }
        public DbSet<RespuestaSoporte> RespuestasSoporte { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolPermiso> RolesPermiso { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<TicketSoporte> TicketsSoporte { get; set; }
        public DbSet<Traduccion> Traducciones { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRol> UsuariosRol { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }
        public DbSet<VotoEncuesta> VotosEncuesta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsuarioRol>()
                .HasKey(ur => new { ur.UsuarioId, ur.RolId });

            // Configuración para la entidad Mensaje
            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.Remitente)
                .WithMany(u => u.MensajesEnviados)
                .HasForeignKey(m => m.RemitenteId);

            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.Destinatario)
                .WithMany(u => u.MensajesRecibidos)
                .HasForeignKey(m => m.DestinatarioId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
