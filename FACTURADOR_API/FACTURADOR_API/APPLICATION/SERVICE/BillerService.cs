using Microsoft.AspNetCore.Mvc;

namespace FACTURADOR_API.APPLICATION.SERVICE
{
    public class BillerService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
