using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Components;

public class CategoriesViewComponent : ViewComponent
{
    #region Methods

    public IViewComponentResult Invoke()
    {
        return View();
    }

    #endregion
}
