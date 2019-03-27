using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DBlazor.HttpClientInterceptor
{
    /// <summary>
    /// 拦截Blazor客户端应用程序上的所有发送的HTTP请求。
    /// </summary>
    public class HttpClientInterceptorService : HttpMessageHandler
    {
        /// <summary>
        /// 在HTTP请求发送之前发生。
        /// </summary>
        public event EventHandler BeforeSend;

        /// <summary>
        /// 在收到HTTP请求的响应后发生。 （包括它没有成功。）
        /// </summary>
        public event EventHandler AfterSend;

        private HttpMessageHandler Handler;

        private readonly MethodInfo SendAsyncMethod;

        internal HttpClientInterceptorService()
        {
            SendAsyncMethod = typeof(HttpMessageHandler).GetMethod(nameof(SendAsync), BindingFlags.Instance | BindingFlags.NonPublic);  // 获取父类的SendAsync方法
        }

        internal void Install(IComponentsApplicationBuilder app)
        {
            if (Handler != null) return;

            var httpClient = app.Services.GetService<HttpClient>();
            var handlerField = typeof(HttpMessageInvoker).GetField("handler", BindingFlags.Instance | BindingFlags.NonPublic);
            Handler = handlerField.GetValue(httpClient) as HttpMessageHandler;

            handlerField.SetValue(httpClient, this);
        }

        /// <summary>
        /// 将Http请求作为异步请求发送
        /// </summary>
        /// <param name="request">要发送的HTTP请求消息。</param>
        /// <param name="cancellationToken">取消操作的取消令牌。</param>
        /// <returns>表示异步操作的任务对象。</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                BeforeSend?.Invoke(this, EventArgs.Empty);
                return await (SendAsyncMethod.Invoke(Handler, new object[] { request, cancellationToken }) as Task<HttpResponseMessage>);  // 调用父类的SendAsync方法
            }
            finally
            {
                AfterSend?.Invoke(this, EventArgs.Empty);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
