using DBlazor;
using DBlazor.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Builder;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用Awesome字体图标的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册Awesome字体图标服务
        /// </summary>
        /// <param name="serviceCollection">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddDCFontAwesomeIcons(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IIconProvider, FontAwesomeIconProvider>();

            return serviceCollection;
        }

        /// <summary>
        /// 将Awesome字体图标服务安装到运行时宿主环境。
        /// </summary>
        /// <param name="app">运行时宿主环境</param>
        /// <returns></returns>
        public static IComponentsApplicationBuilder UseDCFontAwesomeIcons(this IComponentsApplicationBuilder app)
        {
            var componentMapper = app.Services.GetRequiredService<IComponentMapper>();

            componentMapper.Register<DBlazor.Icon, DBlazor.Icons.FontAwesome.Icon>();

            return app;
        }
    }
}
