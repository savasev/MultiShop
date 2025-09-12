using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components;

public class ProductDetailReviewsViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
