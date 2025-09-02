using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents;

public class ProductFilterByPriceViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
