using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDCLocalStorage();  // ע�᱾�ش洢

            services.AddDCToast();  // ע����ʾ��

            services.AddDCLocalisation(); // ע�᱾�ػ�
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseDCLocalisationExtension();  //�������ػ�����

            app.AddComponent<App>("app");
        }
    }
}
