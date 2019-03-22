using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDCLocalStorage();  // 注册本地存储

            services.AddDCToast();  // 注册提示框

            services.AddDCLocalisation(); // 注册本地化
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseDCLocalisationExtension();  //启动本地化操作

            app.AddComponent<App>("app");
        }
    }
}
