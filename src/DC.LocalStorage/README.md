###  **DC.LocalStorage** 

是一个用于访问Blazor应用程序中前端的本地存储类。

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DC.LocalStorage
```

或者通过dotnet CLI

```
dotnet add package DC.LocalStorage
```

或者通过Visual Studio包管理器。

###  **安装** 

1.首先在Startup.cs文件中使用服务集合注册服务

```
public void ConfigureServices (IServiceCollection services)
{
    services.AddDCLocalStorage();
}
```

2.在.cshtml文件中使用


```
@inject DC.LocalStorage.ILocalStorageService localStorage

@functions {

    protected override async Task OnInitAsync()
    {
        await localStorage.SetItem("name", "John Smith");
        var name = await localStorage.GetItem<string>("name");
    }

}

```

或者在_ViewImports.cshtml添加

```
@using DC.LocalStorage
```
然后再在.cshtml文件中使用

```
@inject ILocalStorageService localStorage

@functions {

    protected override async Task OnInitAsync()
    {
        await localStorage.SetItem("name", "John Smith");
        var name = await localStorage.GetItem<string>("name");
    }

}
```


### 标题**可用的API** 

- SetItem(key,value)  存储
- GetItem(key)   获取
- RemoveItem(key) 移除
- Clear()  清除
- Length() 存储项目数量
- Key(index) 指定位置的Key名称


###  **说明** 

1. 所有在ILocalStorageService中的方法都是异步的，如果您使用Blazor（不是Razor组件），您可以选择注入DC.LocalStorage.ISyncStorageService来选择允许您避免使用async/await的同步API。对于任一接口，方法名称都相同。
2. DC.LocalStorage方法将为您处理数据的序列化和反序列化。

