using Microsoft.AspNetCore.Mvc;

namespace Akcay.WebUI.Controllers;

public class AdminLayout : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}