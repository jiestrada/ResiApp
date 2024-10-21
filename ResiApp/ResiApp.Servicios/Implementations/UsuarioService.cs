using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ResiApp.Herramientas;
using ResiApp.Models;
using ResiApp.Services.Data;
using ResiApp.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResiApp.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ResiAppDbContext _context;
        private readonly IConfiguration _configuration;

        public UsuarioService(ResiAppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
                var usuario = _context.Usuarios.Where(u=>u.UsuarioId==id).Include(c=>c.UsuariosRoles).ThenInclude(ur=>ur.Rol).FirstOrDefault();
                if (usuario == null)
                    return new Response<Usuario?>(false, "Usuario no encontrado");

                return new Response<Usuario?>(true, "Usuario encontrado", usuario);
            }
            catch (Exception ex)
            {
                return new Response<Usuario?>(false, $"Error al obtener el usuario: {ex.Message}");
            }
        }

        public Response<Usuario?> GetUsuarioByEmail(string email)
        {
            try
            {
                var usuario = _context.Usuarios.SingleOrDefault(u => u.CorreoElectronico == email);
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
                usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return new Response<string>(true, "Usuario agregado exitosamente");
            }
            catch (Exception ex)
            {
                return new Response<string>(false, $"Error al agregar el usuario: {ex.Message}");
            }
        }

        public Response<string> UpdateUsuario(Usuario usuario, bool cambioPass = false)
        {
            try
            {
                if (cambioPass) usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return new Response<string>(true, "Usuario actualizado exitosamente");
            }

            catch (DbUpdateConcurrencyException)
            {
                return new Response<string>(false, "Error de concurrencia al actualizar el usuario");
            }
            catch (DbUpdateException ex)
            {
                return new Response<string>(false, $"Error al actualizar el usuario: {ex.Message}");
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

        public Response<Usuario?> AuthenticateUser(string email, string password)
        {
            try
            {
                var usuario = _context.Usuarios
                    .Include(u => u.UsuariosRoles)
                    .ThenInclude(ur => ur.Rol)
                    .SingleOrDefault(u => u.CorreoElectronico == email);
                if (usuario == null)
                {
                    return new Response<Usuario?>(false, "Usuario no encontrado");
                }

                // Comparar la contraseña ingresada con el hash almacenado
                if (!BCrypt.Net.BCrypt.Verify(password, usuario.Contrasena))
                {
                    return new Response<Usuario?>(false, "Contraseña incorrecta");
                }

                if (!usuario.Activo)
                {
                    return new Response<Usuario?>(false, "El usuario está inactivo");
                }

                usuario.Login += 1;
                _context.Update(usuario);
                _context.SaveChanges();
                return new Response<Usuario?>(true, "Autenticación exitosa", usuario);
            }
            catch (Exception ex)
            {
                return new Response<Usuario?>(false, $"Error al autenticar el usuario: {ex.Message}");
            }
        }

        public string GenerateToken(Usuario usuario)
        {

            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = usuario.UsuariosRoles.Select(ur => ur.Rol.Nombre).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UsuarioId.ToString()),
        new Claim(ClaimTypes.Email, usuario.CorreoElectronico),
        new Claim(ClaimTypes.Name, usuario.Nombre),
        new Claim(ClaimTypes.Surname, usuario.Apellido),
        new Claim(ClaimTypes.OtherPhone, usuario.Login.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}

