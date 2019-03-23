using DC.LoadingBar;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用LoadingBar的扩展方法
    /// </summary>
    public static class LoadingBarExtension
    {
        /// <summary>
        /// 注册网页加载顶部进度条服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddDCLoadingBar(this IServiceCollection services)
        {
            services.AddDCHttpClientInterceptor();

            if (services.FirstOrDefault(d => d.ServiceType == typeof(LoadingBarService)) == null)
            {
                services.AddSingleton<LoadingBarService>();
            }
        }

    }
}
