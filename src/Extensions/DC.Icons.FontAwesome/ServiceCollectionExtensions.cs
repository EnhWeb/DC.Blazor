using DC.Bue;
using DC.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Builder;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用Awesome字体图标的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDCFontAwesomeIcons(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IIconProvider, FontAwesomeIconProvider>();

            return serviceCollection;
        }

        public static IComponentsApplicationBuilder UseDCFontAwesomeIcons(this IComponentsApplicationBuilder app)
        {
            var componentMapper = app.Services.GetRequiredService<IComponentMapper>();

            componentMapper.Register<DC.Bue.Icon, DC.Icons.FontAwesome.Icon>();

            return app;
        }
    }
}
