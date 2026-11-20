using Microsoft.AspNetCore.Mvc;

namespace Laboratorio13.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
