using Microsoft.AspNetCore.Mvc;
using ResiApp.Services.Interfaces;

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
            var users = _userService.GetAllUsuarios();
            ViewBag.TotUser = users.Data!=null ? users.Data.Count() : 0;
            return View();
        }
    }
}
