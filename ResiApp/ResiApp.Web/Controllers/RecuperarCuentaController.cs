using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Common;
using ResiApp.Services.Implementations;
using ResiApp.Services.Interfaces;
using ResiApp.ViewModel;
using ResiApp.ViewModels.Authenticate;
using System.Security.Policy;

namespace ResiApp.Web.Controllers
{
    public class RecuperarCuentaController : Controller
    {

        private readonly IUsuarioService _userService;
        private readonly IEmailService _emailService;
        public RecuperarCuentaController(IUsuarioService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }
        public IActionResult Index(string token="", string email="")
        {
            if (string.IsNullOrEmpty(token)|| string.IsNullOrEmpty(email))
            {
                return View();
            }

            var response = _userService.GetUsuarioByEmail(email);
            if (response.Data == null) { return View(); }

            var user = response.Data;
            if(user.ResetToken == token && user.ResetTokenExpiry >= DateTime.UtcNow)
            {
                ViewBag.ResetToken = token;
                ViewBag.Email = email;
                return View("CambiarPassword");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarEnlace([FromBody] LoginViewModel model)
        {

            // Buscar al usuario por su correo electrónico
            var response = _userService.GetUsuarioByEmail(model.Email);

            if (response.Data == null)
            {
                return Json(new Response<string>(false, "No encontre tu cuenta, por favor verifica que los datos ingresados sean correctos", null));
            }

            var user = response.Data;
            // Generar un token para restablecer la contraseña
            var resetToken = Guid.NewGuid().ToString(); // Aquí puedes implementar una lógica más avanzada si lo deseas

            user.Activo = true;
            user.ResetToken = resetToken;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);  // El token expira en 1 hora
            var updateUser = _userService.UpdateUsuario(user, false);

            if (!updateUser.Success)
            {
                return Json(new Response<string>(false, "En estos momentos no es posible restablecer tu contraseña, por favor intentalo más tarde.", null));
            }

            // Enviar el correo con el enlace para restablecer la contraseña
            var resetLink = Url.Action("Index", "RecuperarCuenta", new { token = resetToken, email=model.Email }, Request.Scheme);
            var imagen = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/back/images/logo-dark.png";
            //var message = $"Hola {user.Nombre},<br><br>Haz clic en el siguiente enlace para restablecer tu contraseña:<br><a href='{resetLink}'>Restablecer Contraseña</a>";
            var link = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            string message = $@"
        <!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <title>Restablecimiento de Contraseña - ResiApp</title>
</head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e0e0e0; border-radius: 10px;'>
        <div style='text-align: center;'>
            <img src='{imagen}' alt='ResiApp' style='max-width: 150px; margin-bottom: 20px;'>
        </div>
        <h2 style='color: #C70039; text-align: center;'>Restablecimiento de Contraseña</h2>
        <p>Estimado(a) <strong>{user.Nombre} {user.Apellido}</strong>,</p>
        <p>Hemos recibido una solicitud para restablecer tu contraseña en <strong>ResiApp</strong>.</p>
        <p>Para continuar con el proceso de restablecimiento, por favor haz clic en el siguiente enlace:</p>
        <div style='text-align: center; margin: 20px 0;'>
            <a href='{resetLink}' style='padding: 10px 20px; background-color: #C70039; color: white; text-decoration: none; border-radius: 5px;'>Restablecer Contraseña</a>
        </div>
        <p>Este enlace es válido por 1 hora. Si no solicitaste un restablecimiento de contraseña, por favor ignora este correo.</p>
        <br>
        <p>Si tienes alguna pregunta o necesitas asistencia adicional, no dudes en contactarnos.</p>
        <p>Saludos cordiales,<br><strong>El equipo de ResiApp</strong></p>
        <div style='text-align: center; margin-top: 20px;'>
            <a href='{link}' style='text-decoration: none; color: #C70039;'>Visita nuestra web</a>
        </div>
    </div>
</body>
</html>";



            await _emailService.SendEmailAsync(user.CorreoElectronico, "Restablecer Contraseña", message);

            return Json(new Response<string>(true, "Se ha enviado un enlace de restablecimiento a tu correo electrónico", null));
        }

        [HttpPost]
        public IActionResult CambiarPassword([FromBody] LoginViewModel model)
        {
            var response = _userService.GetUsuarioByEmail(model.Email);
            if (response.Data == null) { return View(); }

            var user = response.Data;
            if (user == null)
            {
                return Json(new Response<string>(false, "Token de restablecimiento inválido o expirado", null));
            }

            if (user.ResetToken == model.Token && user.ResetTokenExpiry >= DateTime.UtcNow)
            {
                user.Contrasena = model.Password; // BCrypt.Net.BCrypt.HashPassword(model.Password);
                user.ResetToken = null; // Eliminar el token después de usarlo
                user.ResetTokenExpiry = null;
               var updateUser= _userService.UpdateUsuario(user, true); // true indica que hubo cambio de contraseña
                if (!updateUser.Success)
                {
                    return Json(new Response<string>(false, "En estos momentos no es posible restablecer tu contraseña, por favor intentalo más tarde.", null));
                }
                return Json(new Response<string>(true, "La contraseña ha sido restablecida correctamente", null));
            }

            return Json(new Response<string>(false, "Token de restablecimiento inválido o expirado", null));

        }


    }



}
