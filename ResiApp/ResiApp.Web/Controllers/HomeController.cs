using Microsoft.AspNetCore.Mvc;

namespace ResiApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
