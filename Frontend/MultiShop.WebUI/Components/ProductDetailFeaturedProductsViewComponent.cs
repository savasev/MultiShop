using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components;

public class ProductDetailFeaturedProductsViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
