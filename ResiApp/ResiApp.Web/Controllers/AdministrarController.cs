using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResiApp.Web.Controllers
{
    public class AdministrarController : Controller
    {
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
    }
}
