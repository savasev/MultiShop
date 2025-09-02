using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents;

public class ProductDetailPictureSliderViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
