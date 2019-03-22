using Microsoft.JSInterop;
using System.Globalization;

namespace Microsoft.AspNetCore.Components.Builder
{
    public static class UseBrowserLocalisationExtension
    {
        public static void UseDCLocalisationExtension(this IComponentsApplicationBuilder app)
        {
            var jsRuntime = app.Services.GetService(typeof(IJSRuntime));
            var browserLocale = ((IJSInProcessRuntime)jsRuntime).Invoke<string>("DC.Localisation.GetBrowserLocale");
            var culture = new CultureInfo(browserLocale);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }
}
