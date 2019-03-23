using DC.HttpClientInterceptor;
using Microsoft.JSInterop;
using System;

namespace DC.LoadingBar
{
    public class LoadingBarService : IDisposable
    {
        /// <summary>
        /// Http请求拦截器
        /// </summary>
        private readonly HttpClientInterceptorService Interceptor;

        /// <summary>
        /// JavaScript运行时
        /// </summary>
        private readonly IJSRuntime JSRuntime;

        /// <summary>
        /// 初始化LoadingBar服务实例
        /// </summary>
        /// <param name="interceptor"></param>
        /// <param name="jSRuntime"></param>
        public LoadingBarService(HttpClientInterceptorService interceptor, IJSRuntime jSRuntime)
        {
            Interceptor = interceptor;
            JSRuntime = jSRuntime;

            interceptor.BeforeSend += Interceptor_BeforeSend;
            interceptor.AfterSend += Interceptor_AfterSend;
        }

        private void Interceptor_BeforeSend(object sender, EventArgs e) => BeginLoading();

        private void Interceptor_AfterSend(object sender, EventArgs e) => EndLoading();

        internal void ConstructDOM()
        {
            JSRuntime?.InvokeAsync<object>("eval", "DC.LoadingBar.constructDOM()");
        }

        /// <summary>
        /// 开始加载UI进度条
        /// </summary>
        public void BeginLoading()
        {
            JSRuntime?.InvokeAsync<object>("eval", "DC.LoadingBar.beginLoading()");
        }

        /// <summary>
        /// 结束加载UI进度条
        /// </summary>
        public void EndLoading()
        {
            JSRuntime?.InvokeAsync<object>("eval", "DC.LoadingBar.endLoading()");
        }

        /// <summary>
        /// 取消订阅HttpClientInterceptor提供的事件
        /// </summary>
        public void Dispose()
        {
            Interceptor.BeforeSend -= Interceptor_BeforeSend;
            Interceptor.AfterSend -= Interceptor_AfterSend;
        }
    }
}
