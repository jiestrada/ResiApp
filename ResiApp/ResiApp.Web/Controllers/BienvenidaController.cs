using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResiApp.Services.Interfaces;
using ResiApp.ViewModels.Modals;
using ResiApp.ViewModels.Pages;
using System.Security.Claims;

namespace ResiApp.Web.Controllers
{
    public class BienvenidaController : Controller
    {
        private readonly IUsuarioService _userService;
        public BienvenidaController(IUsuarioService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Súper Administrador,Administrador del Sistema,Administrador del Condominio")]
        public IActionResult Index()
        {
            var respuesta = new BienvenidaViewModel();
            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (usuarioId != null)
            {
                int usuId = 0;
                int.TryParse(usuarioId, out usuId);
                var response = _userService.GetUsuarioById(usuId);
                if (response != null && response.Data != null)
                {
                    var usu = response.Data;
                    var rol = usu.UsuariosRoles.FirstOrDefault();
                    if (rol != null && !string.IsNullOrEmpty(rol.Rol.Mensaje))
                    {
                        string strMensaje = rol.Rol.Mensaje.Replace("{0}", usu.Nombre.TrimStart() + " " + usu.Apellido.TrimEnd());
                        respuesta.Mensaje = strMensaje;
                    }
                    return View(respuesta);
                }
            }
            return View(respuesta);
        }
    }
}
