using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class CategoryController : BaseAdminController
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public async Task<IActionResult> List()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("http://localhost:7070/api/categories");




        return View();
    }

    #endregion
}
