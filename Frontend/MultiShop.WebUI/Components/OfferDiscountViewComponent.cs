using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components;

public class OfferDiscountViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
