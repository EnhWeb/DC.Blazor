###  **DBlazor.Toast** 

是一个用于Blazor中弹出消息提示框的组件。

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DBlazor.Toast
```

或者通过dotnet CLI

```
dotnet add package DBlazor.Toast
```

或者通过Visual Studio包管理器。

###  **建立** 

1.首先在Startup.cs文件中使用服务集合注册服务

```
public void ConfigureServices (IServiceCollection services)
{
    services.AddDCToast();
}
```

2.在_ViewImports.cshtml文件中引用

```
@using DBlazor
@using DBlazor.Toast.Services

@addTagHelper *, DBlazor.Toast
```

3.在MainLayout.cshtml中注册Toast组件

```
<DCToasts />
```

###  **用法** 

```
@page "/toast"
@inject IToastService toastService

<button class="btn btn-info" onclick="@(() => toastService.ShowToast(ToastLevel.Info, "I'm an INFO message"))">Info Toast</button>
<button class="btn btn-success" onclick="@(() => toastService.ShowToast(ToastLevel.Success, "I'm a SUCCESS message with a custom heading", "Congratulations!"))">Success Toast</button>
<button class="btn btn-warning" onclick="@(() => toastService.ShowToast(ToastLevel.Warning, "I'm a WARNING message"))">Warning Toast</button>
<button class="btn btn-danger" onclick="@(() => toastService.ShowToast(ToastLevel.Error, "I'm an ERROR message"))">Error Toast</button>
```