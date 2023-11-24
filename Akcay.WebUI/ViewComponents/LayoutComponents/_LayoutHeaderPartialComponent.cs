using Microsoft.AspNetCore.Mvc;

namespace Akcay.WebUI.ViewComponents.LayoutComponents;

public class _LayoutHeaderPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }   
}