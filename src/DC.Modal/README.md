###  **DC.Modal** 

是一个用于Blazor中模态窗口的组件。

###  **安装** 

您可以使用以下命令从Nuget安装：

```
Install-Package DC.Modal
```

或者通过dotnet CLI

```
dotnet add package DC.Modal
```

或者通过Visual Studio包管理器。

###  **建立** 

1.首先在Startup.cs文件中使用服务集合注册服务

```
public void ConfigureServices (IServiceCollection services)
{
    services.AddDCModal();
}
```

2.在_ViewImports.cshtml文件中引用

```
@using DC
@using DC.Modal
@using DC.Modal.Services

@addTagHelper *, DC.Modal
```

3.在MainLayout.cshtml中注册Toast组件

```
<DCModal />
```

###  **用法** 

```
@page "/modal"
@inject IModalService Modal

<h1>Hello, world!</h1>

Welcome to your new app.

<hr class="mb-5" />

<button onclick="@(ShowModal)" class="btn btn-primary">Show Modal</button>

@functions {

    void ShowModal()
    {
        var parameters = new ModalParameters();

        parameters.Add("FormId", 11);

        Modal.OnClose += ModalClosed;
        Modal.Show("Sign Up Form", typeof(SignUpForm), parameters);
    }

    void ModalClosed()
    {
        Console.WriteLine("Modal has closed");
        Modal.OnClose -= ModalClosed;
    }

}
```

```
@inject IModalService Modal
@if (ShowForm)
{
<div class="simple-form">

    <div class="form-group">
        <label for="first-name">First Name</label>
        <input bind="@FirstName" type="text" class="form-control" id="first-name" placeholder="Enter First Name" />
    </div>

    <div class="form-group">
        <label for="last-name">Last Name</label>
        <input bind="@LastName" type="text" class="form-control" id="last-name" placeholder="Enter Last Name" />
    </div>

    <button onclick="@SubmitForm" class="btn btn-primary">Submit</button>
    <button onclick="@Cancel" class="btn btn-secondary">Cancel</button>
</div>
}
else
{
<div class="alert alert-success" role="alert">
    Thanks @FirstName @LastName, form (Id: @FormId) submitted successfully.
</div>
}

@functions {

    [CascadingParameter] ModalParameters Parameters { get; set; }

    bool ShowForm { get; set; } = true;
    string FirstName { get; set; }
    string LastName { get; set; }
    int FormId { get; set; }

    protected override void OnInit()
    {
        FormId = Parameters.Get<int>("FormId");
    }

    void SubmitForm()
    {
        ShowForm = false;
    }

    void Cancel()
    {
        Modal.Close();
    }

}
```