#region Using directives
using DC.Bue;
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

            componentMapper.Register<DC.Bue.Icon, Material.Icon>();

            return app;
        }
    }
}
