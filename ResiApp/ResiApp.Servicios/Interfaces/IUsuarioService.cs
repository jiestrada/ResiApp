using ResiApp.Herramientas;
using ResiApp.Models;

namespace ResiApp.Services.Interfaces
{
    public interface IUsuarioService
    {
        Response<IEnumerable<Usuario>> GetAllUsuarios();
        Response<Usuario?> GetUsuarioById(int id);
        Response<string> AddUsuario(Usuario usuario);
        Response<string> UpdateUsuario(Usuario usuario);
        Response<string> DeleteUsuario(int id);
    }
}
