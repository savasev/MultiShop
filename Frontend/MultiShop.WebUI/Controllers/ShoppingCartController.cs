using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers;

public class ShoppingCartController : Controller
{
	#region Methods

	public IActionResult Index()
	{
		return RedirectToAction("Cart");
	}

	public IActionResult Cart()
	{
		return View();
	}

	#endregion
}
