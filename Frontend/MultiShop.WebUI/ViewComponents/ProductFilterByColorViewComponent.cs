using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents;

public class ProductFilterByColorViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
