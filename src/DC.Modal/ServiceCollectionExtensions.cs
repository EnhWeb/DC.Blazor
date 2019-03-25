using DC.Modal.Services;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 添加和使用弹窗的扩展方法
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static void AddDCModal(this IServiceCollection services)
        {
            if (services.FirstOrDefault(d => d.ServiceType == typeof(IModalService)) == null)
            {
                services.AddScoped<IModalService, ModalService>();
            }
        }
    }
}
