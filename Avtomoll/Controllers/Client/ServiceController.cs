using Microsoft.AspNetCore.Mvc;

namespace Avtomoll.Controllers.Client
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
