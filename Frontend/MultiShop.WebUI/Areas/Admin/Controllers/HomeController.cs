using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class HomeController : BaseAdminController
{
    #region Methods

    public IActionResult Index()
    {
        return RedirectToAction("Dashboard");
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    #endregion
}
