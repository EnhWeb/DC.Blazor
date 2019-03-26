using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DC.Icons.FontAwesome
{
    /// <summary>
    /// 添加和使用Awesome字体图标的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDCFontAwesomeIcons(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConProvider, FontAwesomeIconProvider>();

            return serviceCollection;
        }

        public static IComponentsApplicationBuilder UseDCFontAwesomeIcons(this IComponentsApplicationBuilder app)
        {
            var componentMapper = app.Services.GetRequiredService<IComponentMapper>();

            componentMapper.Register<DC.Bue.Icon, FontAwesome.Icon>();

            return app;
        }
    }
}
