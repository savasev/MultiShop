namespace MultiShop.WebUI.Areas.Admin.Helpers;

public static class MenuItems
{
    #region Catalog Menu Items

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
        }
    };

    #endregion
}
