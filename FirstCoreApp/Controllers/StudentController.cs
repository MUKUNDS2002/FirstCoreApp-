using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() 
        {
            return View();
        }
        public IActionResult Update() 
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
