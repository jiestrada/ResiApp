using ResiApp.Herramientas;
using ResiApp.Models;

namespace ResiApp.Services.Interfaces
{
    public interface IUsuarioService
    {
        Response<IEnumerable<Usuario>> GetAllUsuarios();
        Response<Usuario?> GetUsuarioById(int id);
        Response<string> AddUsuario(Usuario usuario);
        Response<string> UpdateUsuario(Usuario usuario, bool cambioPass = false);
        Response<string> DeleteUsuario(int id);
        Response<Usuario?> AuthenticateUser(string email, string password);
        Response<Usuario?> GetUsuarioByEmail(string email);
        string GenerateToken(Usuario usuario);
    }
}
