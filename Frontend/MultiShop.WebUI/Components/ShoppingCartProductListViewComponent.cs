using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components;

public class ShoppingCartProductListViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
