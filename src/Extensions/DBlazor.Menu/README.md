###  **DBlazor.Menu** 

是一个用于访问Blazor应用程序中的自定义菜单组件。

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DBlazor.Menu
```

或者通过dotnet CLI

```
dotnet add package DBlazor.Menu
```

或者通过Visual Studio包管理器。

###  **添加引用** 

1.在_ViewImports.cshtml中添加下面代码

```
@using DBlazor.Menu
@addTagHelper *, DBlazor.Menu
```

###  **用法**

1.使用以下组件构建菜单：
- DCMenu
- DCMenuItem
- DCSubMenu

```
<DCMenu>
    <DCMenuItem>
        <NavLink href="" Match="NavLinkMatch.All">Home</NavLink>
    </DCMenuItem>
    <DCMenuItem>
        <NavLink href="counter">Counter</NavLink>
    </DCMenuItem>
    <DCSubMenu Header="Sub Menu">
        <DCMenuItem>
            <NavLink href="counter">Counter</NavLink>
        </DCMenuItem>
        <DCMenuItem>
            <NavLink href="fetchdata">Fetch data</NavLink>
        </DCMenuItem>
    </DCSubMenu>
    <DCMenuItem>
        <NavLink href="fetchdata">Fetch data</NavLink>
    </DCMenuItem>
</DCMenu>
```

2.使用MenuBuilder动态构建菜单

您可以使用AddItem和AddSubMenu构建菜单。

```
<DCMenu MenuBuilder="@MenuBuilder" />

<DCMenu ChildContent="@ChildContent" />

@functions {
    MenuBuilder MenuBuilder = new MenuBuilder();

    RenderFragment ChildContent = null;

    protected override void OnInit()
    {
        MenuBuilder.AddItem(1, "Home", "/")
                   .AddItem(2, "Counter1", "counter", IsEnabled: false)
                   .AddSubMenu(3, "Sub Menu", new MenuBuilder().AddItem(1, "Counter", "counter")
                                                               .AddItem(2, "Fetch Data", "fetchdata", IsEnabled: false)
                                                               .AddItem(3, "You Can't See Me", "invisible", IsVisible: false))
                   .AddItem(4, "FetchData", "fetchdata");

        ChildContent = new RenderFragment(b =>
        {
            b.OpenComponent<DCMenuItem>(0);
            b.AddAttribute(1, "IsEnabled", true);
            b.AddAttribute(2, "IsVisible", true);
            b.AddAttribute(3, "ChildContent", new RenderFragment(c =>
            {
                c.AddContent(4, "测试");
            }));
            b.CloseComponent();
        });
    }
}
```