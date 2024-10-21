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
                Telefono = "",
                Login=0
            };

            var rolInquilino = new UsuarioRol
            {
                Usuario = nuevoUsuario,
                RolId = 3,
                Activo = true
            };

            nuevoUsuario.UsuariosRoles = new List<UsuarioRol> { rolInquilino };

            // Registrar el usuario en el servicio
            var addResponse = _userService.AddUsuario(nuevoUsuario);

            if (!addResponse.Success)
            {
                return Json(new Response<string>(false, addResponse.Message, null));
            }

            string subject = "¡Bienvenido a ResiApp!";


            //string body = $"Hola {nuevoUsuario.Nombre},<br><br>Te damos la bienvenida a ResiApp. Ya puedes comenzar a gestionar tu condominio.";
            var link = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            var imagen = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/back/images/logo-dark.png";
            string body = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='UTF-8'>
            <title>Bienvenido a ResiApp</title>
        </head>
        <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
            <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 10px;'>
                <div style='text-align: center;'>
                    <img src='{imagen}' alt='ResiApp' style='max-width: 150px; margin-bottom: 20px;'>
                </div>
                <h2 style='color: #C70039; text-align: center;'>¡Bienvenido a ResiApp!</h2>
                <p>Estimado(a) <strong>{nuevoUsuario.Nombre} {nuevoUsuario.Apellido}</strong>,</p>
                <p>Es un placer darte la bienvenida a <strong>ResiApp</strong>, la plataforma diseñada para facilitar la gestión de condominios y la comunicación con tus residentes.</p>
                <p>Ahora que eres parte de ResiApp, puedes comenzar a gestionar tu condominio de manera eficiente, desde la administración de unidades y residentes hasta la gestión de pagos y mantenimiento.</p>
                <p>Para comenzar, inicia sesión con tu correo registrado y disfruta de todas las herramientas que hemos creado para ti.</p>
                <p>Si tienes alguna duda o necesitas asistencia, no dudes en contactarnos. Estamos aquí para ayudarte.</p>
                <br>
                <p style='text-align: center;'>¡Bienvenido a la comunidad de ResiApp!</p>
                <p>Saludos cordiales,<br><strong>El equipo de ResiApp</strong></p>
                <div style='text-align: center; margin-top: 20px;'>
                    <a href='{link}' style='text-decoration: none; color: #C70039;'>Visita nuestra web</a>
                </div>
            </div>
        </body>
        </html>";


            await _emailService.SendEmailAsync(nuevoUsuario.CorreoElectronico, subject, body);


            // Si el registro es exitoso
            return Json(new Response<RegisterViewModel>(true, "Usuario registrado exitosamente", registerRequest));
        }



    }
}
