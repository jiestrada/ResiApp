﻿using Microsoft.AspNetCore.Mvc;
using ResiApp.Models;
using ResiApp.Services.Interfaces;
using ResiApp.ViewModel;
using ResiApp.ViewModels.Authenticate;

namespace ResiApp.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _userService;
        public LoginController(IUsuarioService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody]  LoginViewModel loginRequest)
        {
            var authResponse = _userService.AuthenticateUser(loginRequest.Email, loginRequest.Password);

            if (!authResponse.Success)
            {
                return Json(new Response<string>(false, authResponse.Message, null));
            }

            var token = _userService.GenerateToken(authResponse.Data!);
            HttpContext.Response.Cookies.Append("AuthTokenResiApp", token, new CookieOptions
            {
                HttpOnly = true, // Protege el token para que no sea accesible desde JavaScript
                Secure = true, // Solo se envía en conexiones HTTPS
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(60) // La duración debe coincidir con la expiración del token
            });

            return Json(new Response<string>(true, authResponse.Message, null));

        }

    }
}
