using Microsoft.AspNetCore.Mvc.Rendering;

namespace MultiShop.WebUI.Areas.Admin.Helpers;

public static class HtmlHelpers
{
    #region Methods

    public static string MenuOpen(this IHtmlHelper html, Dictionary<string, string[]> items)
    {
        var routeData = html.ViewContext.RouteData;
        var routeController = routeData.Values["controller"]?.ToString();
        var routeAction = routeData.Values["action"]?.ToString();

        foreach (var item in items)
        {
            var controllerMatch = item.Key == routeController;
            var actionMatch = item.Value == null || item.Value.Length == 0 || item.Value.Contains(routeAction);

            if (controllerMatch && actionMatch)
            {
                return "menu-open";
            }
        }

        return string.Empty;
    }

    public static string ActiveClass(this IHtmlHelper html, Dictionary<string, string[]> items, string controller)
    {
        var routeData = html.ViewContext.RouteData;
        var routeController = routeData.Values["controller"]?.ToString();
        var routeAction = routeData.Values["action"]?.ToString();

        if (items.ContainsKey(controller))
        {
            var actions = items[controller];
            var actionMatch = actions == null || actions.Length == 0 || actions.Contains(routeAction);

            if (controller == routeController && actionMatch)
                return "active";
        }

        return string.Empty;
    }

    #endregion
}
