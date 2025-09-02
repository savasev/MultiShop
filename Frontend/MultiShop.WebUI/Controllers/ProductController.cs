using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class ProductController : Controller
{
    #region Methods

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View();
    }

    public IActionResult ProductDetails()
    {
        return View();
    }

    #endregion
}
