#region Using directives
using DBlazor;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace DC.Icons.Material
{
    public static class Config
    {
        public static IServiceCollection AddMaterialIcons( this IServiceCollection serviceCollection )
        {
            serviceCollection.AddSingleton<IIconProvider, MaterialIconProvider>();

            return serviceCollection;
        }

        public static IComponentsApplicationBuilder UseMaterialIcons( this IComponentsApplicationBuilder app )
        {
            var componentMapper = app.Services.GetRequiredService<IComponentMapper>();

            componentMapper.Register<DBlazor.Icon, Material.Icon>();

            return app;
        }
    }
}
