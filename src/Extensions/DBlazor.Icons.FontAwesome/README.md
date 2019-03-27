###  **DC.Icons.FontAwesome** 

是一个基于FontAwesome的字体图标组件。

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DC.Icons.FontAwesome
```

或者通过dotnet CLI

```
dotnet add package DC.Icons.FontAwesome
```

或者通过Visual Studio包管理器。

###  **建立** 

1.在Startup.cs文件中使用服务集合注册服务

```
public void ConfigureServices (IServiceCollection services)
{
    services.AddDCBue()
	  .AddDCEmptyProviders()
      .AddDCFontAwesomeIcons();
}
```

2.在Startup.cs文件中启用组件
```
public void Configure(IComponentsApplicationBuilder app)
{
    app.UseDCFontAwesomeIcons();
    app.AddComponent<App>("app");
}
```

###  **用法** 

```
@addTagHelper *, DBlazor
@using DBlazor

<Icon Name="IconName.Dashboard" Margin="Margin.Is3.FromRight" />

```