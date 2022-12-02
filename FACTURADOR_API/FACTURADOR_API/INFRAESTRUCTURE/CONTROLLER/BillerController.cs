using Microsoft.AspNetCore.Mvc;

namespace FACTURADOR_API.INFRAESTRUCTURE.CONTROLLER
{
    public class BillerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
