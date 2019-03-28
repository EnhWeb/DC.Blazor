###  **DBlazor.HttpClientInterceptor** 

是一个用于Blazor中拦截Blazor应用程序上所有发送HTTP请求的类库。

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DBlazor.HttpClientInterceptor
```

或者通过dotnet CLI

```
dotnet add package DBlazor.HttpClientInterceptor
```

或者通过Visual Studio包管理器。

###  **建立** 

1.在Startup.cs文件中使用服务集合注册服务

```
public void ConfigureServices (IServiceCollection services)
{
    services.AddDCHttpClientInterceptor();
}
```

2.在Startup.cs文件中启用HTTP请求拦截组件
```
public void Configure(IComponentsApplicationBuilder app)
{
    app.UseDCHttpClientInterceptor();  // 启用Http请求拦截器
    app.AddComponent<App>("app");
}
```

2.可以在任何可以从DI窗口获取HttpClientInterceptor服务的地方订阅所有发送HTTP请求之前/之后发生的事件。

```
@using DBlazor.HttpClientInterceptor
@inject HttpClientInterceptorService Interceptor
```

###  **用法** 

```
@using DBlazor.HttpClientInterceptor
@inject HttpClientInterceptorService Interceptor

@functions {
  protected override void OnInit()
  {
    this.Interceptor.BeforeSend += Interceptor_BeforeSend;
	this.Interceptor.AfterSend += Interceptor_AfterSend;
  }

  void Interceptor_BeforeSend(object sender, EventArgs e)
  {
    // Do something here what you want to do.
  }

  void Interceptor_AfterSend(object sender, EventArgs e)
  {
    // Do something here what you want to do.
  }

```

###  **注意** 

如果您使用Blazor(.cshtml)中的HttpClientInterceptor订阅的BeforeSend/AfterSend事件，则应在组件被区分时取消订阅事件。要做到这一点，您应该在该组件中实现接口IDisposable。

```
@implements IDisposable

public void Dispose()
{
  this.Interceptor.BeforeSend -= Interceptor_BeforeSend;
}
```