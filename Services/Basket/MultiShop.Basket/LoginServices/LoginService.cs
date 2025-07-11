namespace MultiShop.Basket.LoginServices;

public class LoginService : ILoginService
{
    #region Fields

    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion

    #region Ctor

    public LoginService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    #endregion

    #region Methods

    public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;

    #endregion
}
