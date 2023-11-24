using Microsoft.AspNetCore.Mvc;

namespace Akcay.WebUI.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}