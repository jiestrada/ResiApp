using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResiApp.Services.Interfaces;
using ResiApp.ViewModels.Modals;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ResiApp.Web.Controllers
{
    public class AdministrarController : Controller
    {
        private readonly IUsuarioService _userService;
        public AdministrarController(IUsuarioService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Súper Administrador,Administrador del Sistema,Administrador del Condominio")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Súper Administrador")]
        public IActionResult Condominios()
        {
            return View();
        }

        [Authorize(Roles = "Súper Administrador,Administrador del Sistema,Administrador del Condominio")]
        public IActionResult ModalBienvenida()
        {
            var respuesta = new ModalBienvenidaViewModel();
            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (usuarioId != null) {
                int usuId = 0;
                int.TryParse(usuarioId, out usuId);
                var response = _userService.GetUsuarioById(usuId);
                if (response != null && response.Data!=null) {
                    var usu = response.Data;
                    var rol = usu.UsuariosRoles.FirstOrDefault();
                    if (rol != null && !string.IsNullOrEmpty( rol.Rol.Mensaje)) {
                        string strMensaje = rol.Rol.Mensaje.Replace("{0}", usu.Nombre.TrimStart() + " " + usu.Apellido.TrimEnd() );
                        respuesta.Mensaje = strMensaje;
                    }
                    return PartialView(respuesta);
                } 
            }
            return PartialView(respuesta);
        }

    }
}
