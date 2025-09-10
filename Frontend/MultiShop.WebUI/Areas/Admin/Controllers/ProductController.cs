using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

public class ProductController : BaseAdminController
{
    #region Fields

    private readonly IHttpClientFactory _httpClientFactory;

    #endregion

    #region Ctor

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion

    #region Methods

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProductList()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7070/api/products");

        if (!response.IsSuccessStatusCode)
            return Json(new { data = new List<ResultProductDto>() });

        var jsonData = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

        return Json(new { data = products });
    }

    public IActionResult Create()
    {
        return View(new CreateProductDto());
    }

    #endregion
}
