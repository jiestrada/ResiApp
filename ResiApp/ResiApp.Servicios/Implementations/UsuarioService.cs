using Microsoft.EntityFrameworkCore;
using ResiApp.Herramientas;
using ResiApp.Models;
using ResiApp.Services.Data;
using ResiApp.Services.Interfaces;

namespace ResiApp.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ResiAppDbContext _context;

        public UsuarioService(ResiAppDbContext context)
        {
            _context = context;
        }

        public Response<IEnumerable<Usuario>> GetAllUsuarios()
        {
            try
            {
                var usuarios = _context.Usuarios.ToList();
                return new Response<IEnumerable<Usuario>>(true, "Usuarios obtenidos exitosamente", usuarios);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Usuario>>(false, $"Error al obtener usuarios: {ex.Message}");
            }
        }

        public Response<Usuario?> GetUsuarioById(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                    return new Response<Usuario?>(false, "Usuario no encontrado");

                return new Response<Usuario?>(true, "Usuario encontrado", usuario);
            }
            catch (Exception ex)
            {
                return new Response<Usuario?>(false, $"Error al obtener el usuario: {ex.Message}");
            }
        }

        public Response<string> AddUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return new Response<string>(true, "Usuario agregado exitosamente");
            }
            catch (Exception ex)
            {
                return new Response<string>(false, $"Error al agregar el usuario: {ex.Message}");
            }
        }

        public Response<string> UpdateUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return new Response<string>(true, "Usuario actualizado exitosamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                return new Response<string>(false, "Error de concurrencia al actualizar el usuario");
            }
            catch (Exception ex)
            {
                return new Response<string>(false, $"Error al actualizar el usuario: {ex.Message}");
            }
        }

        public Response<string> DeleteUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                    return new Response<string>(false, "Usuario no encontrado");

                usuario.Activo = false;
                _context.Update(usuario);
                _context.SaveChanges();
                return new Response<string>(true, "Usuario eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return new Response<string>(false, $"Error al eliminar el usuario: {ex.Message}");
            }
        }
    }
}

