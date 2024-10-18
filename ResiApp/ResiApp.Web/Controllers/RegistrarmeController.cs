using Microsoft.AspNetCore.Mvc;
using ResiApp.Models;
using ResiApp.Services.Implementations;
using ResiApp.Services.Interfaces;
using ResiApp.ViewModel;
using ResiApp.ViewModels.Authenticate;

namespace ResiApp.Web.Controllers
{
    public class RegistrarmeController : Controller
    {
        private readonly IUsuarioService _userService;
        private readonly IEmailService _emailService;
        public RegistrarmeController(IUsuarioService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return Json(new Response<string>(false, "Datos inválidos", null));
            }

            // Verificar si el usuario ya existe en la base de datos
            var existingUser = _userService.GetUsuarioByEmail(registerRequest.CorreoElectronico);
            if (existingUser.Data != null)
            {
                return Json(new Response<string>(false, "El correo electrónico ya está registrado", null));
            }

            // Crear el nuevo usuario
            var nuevoUsuario = new Usuario
            {
                Nombre = registerRequest.Nombre,
                Apellido = registerRequest.Apellido,
                CorreoElectronico = registerRequest.CorreoElectronico,
                Contrasena = registerRequest.Contrasena, // Será hasheada en el servicio
                Activo = true,
                FechaCreacion = DateTime.UtcNow,
                Telefono = ""
            };

            var rolInquilino = new UsuarioRol
            {
                Usuario = nuevoUsuario,
                RolId = 3 // ID del rol "Residente Inquilino"
            };

            nuevoUsuario.UsuariosRoles = new List<UsuarioRol> { rolInquilino };

            // Registrar el usuario en el servicio
            var addResponse = _userService.AddUsuario(nuevoUsuario);

            if (!addResponse.Success)
            {
                return Json(new Response<string>(false, addResponse.Message, null));
            }

            string subject = "¡Bienvenido a ResiApp!";
            string body = $"Hola {nuevoUsuario.Nombre},<br><br>Te damos la bienvenida a ResiApp. Ya puedes comenzar a gestionar tu condominio.";
            await _emailService.SendEmailAsync(nuevoUsuario.CorreoElectronico, subject, body);


            // Si el registro es exitoso
            return Json(new Response<RegisterViewModel>(true, "Usuario registrado exitosamente", registerRequest));
        }



    }
}
