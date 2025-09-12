using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components;

public class ProductListViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
