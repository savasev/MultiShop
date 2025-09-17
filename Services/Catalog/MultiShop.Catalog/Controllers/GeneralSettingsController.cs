using MultiShop.Catalog.Services.GeneralSettingServices;

namespace MultiShop.Catalog.Controllers;

public class GeneralSettingsController : BaseApiController
{
	#region Fields

	private readonly IGeneralSettingService _generalSettingService;

    #endregion

    #region Ctor

    public GeneralSettingsController(IGeneralSettingService generalSettingService)
    {
        _generalSettingService = generalSettingService;
    }

    #endregion

    #region Methods



    #endregion
}
