###  **DC.Menu** 

是一个用于访问Blazor应用程序中的自定义菜单组件。

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DC.Menu
```

或者通过dotnet CLI

```
dotnet add package DC.Menu
```

或者通过Visual Studio包管理器。

###  **添加引用** 

1.在_ViewImports.cshtml中添加下面代码

```
@using DC.Menu
@addTagHelper *, DC.Menu
```

###  **用法**

1.使用以下组件构建菜单：