using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace DC.Localisation
{
    public class LocalisationService : ILocalisationService
    {
        private readonly IJSRuntime _jSRuntime;  //表示可以调度调用的JavaScript运行时的实例。
        private readonly IJSInProcessRuntime _jsInProcessRuntime;  //表示可以调度调用的JavaScript运行时的实例。

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="jSRuntime">JavaScript运行时</param>
        public LocalisationService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            _jsInProcessRuntime = jSRuntime as IJSInProcessRuntime;
        }

        /// <summary>
        /// 注册本地化数据
        /// </summary>
        public CultureInfo Register()
        {
            var browserLocale = _jsInProcessRuntime.Invoke<string>("DC.Localisation.GetBrowserLocale");
            var culture = new CultureInfo(browserLocale);

            return culture;
        }

    }
}
