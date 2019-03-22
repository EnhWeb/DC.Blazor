namespace Microsoft.Extensions.DependencyInjection
{
    public static class LoadingBarExtension
    {
        /// <summary>
        /// 注册网页加载顶部进度条服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddDCLoadingBar(this IServiceCollection services)
        {
            services.AddHttpClientInterceptor();
        }

    }
}
