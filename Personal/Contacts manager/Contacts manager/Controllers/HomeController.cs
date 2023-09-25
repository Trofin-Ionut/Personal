using Microsoft.AspNetCore.Mvc;

namespace Contacts_manager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
