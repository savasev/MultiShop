using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Catalog.Controllers;

[AllowAnonymous]
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
}
