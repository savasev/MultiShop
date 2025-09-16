namespace MultiShop.WebUI.Areas.Admin.Helpers;

public static class MenuItems
{
    #region Catalog Menu Items

    public static readonly Dictionary<string, string[]> RootMenuItems = new()
    {
        {
            "Home",
            new[]
            {
                "Dashboard"
            }
        },
    };

    public static readonly Dictionary<string, string[]> Catalogs = new()
    {
        {
            "Category",
            new[]
            {
                "List", "Create", "Edit"
            }
        },
        {
            "Product",
            new[]
            {
                "List", "Create", "Edit"
            }
        },
        {
            "FeatureSlider",
            new[]
            {
                "List", "Create", "Edit"
            }
        },
        {
            "SpecialOffer",
            new[]
            {
                "List", "Create", "Edit"
            }
        },
        {
            "Feature",
            new[]
            {
                "List", "Create", "Edit"
            }
        },
        {
            "OfferDiscount",
            new[]
            {
                "List", "Create", "Edit"
            }
        },
        {
            "Brand",
            new[]
            {
                "List", "Create", "Edit"
            }
        }
    };

    public static readonly Dictionary<string, string[]> Settings = new()
    {
        {
            "SiteInfo",
            new[]
            {
                "List", "Create", "Edit"
            }
        },
    };

    #endregion
}
