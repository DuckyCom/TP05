using Microsoft.AspNetCore.Mvc;

namespace TP05.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
