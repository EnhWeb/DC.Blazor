###  **DC.LoadingBar** 

是一个用于访问Blazor应用程序中Http请求网页顶部进度条。

![输入图片说明](https://images.gitee.com/uploads/images/2019/0323/143832_e9beece3_130171.gif "演示图片")

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DC.LoadingBar
```

或者通过dotnet CLI

```
dotnet add package DC.LoadingBar
```

或者通过Visual Studio包管理器。

###  **建立** 

1.首先在Startup.cs文件中使用服务集合注册服务并启用

```
public void ConfigureServices (IServiceCollection services)
{
    services.AddDCLoadingBar();
}

public void Configure(IComponentsApplicationBuilder app)
{
    app.UseDCLoadingBar();
}
```

通过上面操作即可直接使用。

 **注意：** 该方法仅适用于有http请求的页面，且只有第一次打开相关的页面才有进度条，打开之后再次打开是看不到的。