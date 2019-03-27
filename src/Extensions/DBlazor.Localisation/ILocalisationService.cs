using System.Globalization;
using System.Threading.Tasks;

namespace DBlazor.Localisation
{
    public interface ILocalisationService
    {
        /// <summary>
        /// 注册本地化数据
        /// </summary>
        CultureInfo Register();
    }
}
