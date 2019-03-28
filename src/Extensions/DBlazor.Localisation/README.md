###  **DBlazor.Localisation** 

是一个用于访问Blazor应用程序中前端的本地化组件。

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DBlazor.Localisation
```

或者通过dotnet CLI

```
dotnet add package DBlazor.Localisation
```

或者通过Visual Studio包管理器。

###  **建立** 

该组件有两种不同的安装方法

第一种方法：

1.在startup.cs文件中添加```app.UseDCLocalisationExtension();```

```
public void Configure(IBlazorApplicationBuilder app)
{
    app.UseBlazoredLocalisation();
    app.AddComponent<App>("app");
}
```

2.在.cshtml文件中添加```@using System.Globalization```

```
<p>The current date and time is: <strong>@DateTime.Now</strong></p>
<hr />
<p>Current Culture: <strong>@CultureInfo.CurrentUICulture.DisplayName</strong></p>
<p>Current Culture Code: <strong>@CultureInfo.CurrentCulture.Name</strong></p>
<p>Current UI Culture Code: <strong>@CultureInfo.CurrentUICulture.Name</strong></p>
<p>Current Culture Currency Symbol: <strong>@CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol</strong></p>
<p>Current Culture DateTime Pattern: <strong>@CultureInfo.CurrentUICulture.DateTimeFormat.FullDateTimePattern</strong></p>
```

上面方法适合于首页不需要切换页面的方式，如果切换页面会发现获取不到本地化数据。

第一种方法：

1.在startup.cs文件中添加```services.AddDCLocalisation();```

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddDCLocalisation();
}
```

2.在.cshtml中添加引用
```
@using DBlazor.Localisation
@inject ILocalisationService localisationService
```

```
@using DBlazor.Localisation
@inject ILocalisationService localisationService

<p>The current date and time is: <strong>@DateTime.Now</strong></p>
<hr />
<p>Current Culture: <strong>@culture.DisplayName</strong></p>
<p>Current Culture Code: <strong>@culture.Name</strong></p>
<p>Current UI Culture Code: <strong>@culture.Name</strong></p>
<p>Current Culture Currency Symbol: <strong>@culture.NumberFormat.CurrencySymbol</strong></p>
<p>Current Culture DateTime Pattern: <strong>@culture.DateTimeFormat.FullDateTimePattern</strong></p>

@functions{

    CultureInfo culture { get; set; }

    protected override void OnInit()
    {
        culture = localisationService.Register();
        Console.WriteLine(culture.DisplayName);
    }
}
```