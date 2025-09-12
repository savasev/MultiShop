using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components;

public class ProductDetailInformationViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
