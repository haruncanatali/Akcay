﻿using Microsoft.AspNetCore.Mvc;

namespace Akcay.WebUI.ViewComponents.LayoutComponents;

public class _LayoutScriptPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}