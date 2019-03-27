#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace DBlazor.Bulma
{
    public static class Config
    {
        public static IServiceCollection AddBulmaProviders( this IServiceCollection serviceCollection, Action<IClassProvider> configureClassProvider = null )
        {
            var classProvider = new BulmaClassProvider();

            configureClassProvider?.Invoke( classProvider );

            serviceCollection.AddSingleton<IClassProvider>( classProvider );
            serviceCollection.AddSingleton<IStyleProvider, BulmaStyleProvider>();
            serviceCollection.AddSingleton<IJSRunner, BulmaJSRunner>();
            serviceCollection.AddSingleton<IComponentMapper, ComponentMapper>();

            return serviceCollection;
        }

        public static IComponentsApplicationBuilder UseBulmaProviders( this IComponentsApplicationBuilder app )
        {
            var componentMapper = app.Services.GetRequiredService<IComponentMapper>();

            componentMapper.Register<DBlazor.Addons, Bulma.Addons>();
            componentMapper.Register<DBlazor.BarToggler, Bulma.BarToggler>();
            componentMapper.Register<DBlazor.BarDropdown, Bulma.BarDropdown>();
            componentMapper.Register<DBlazor.Breadcrumb, Bulma.Breadcrumb>();
            componentMapper.Register<DBlazor.BreadcrumbLink, Bulma.BreadcrumbLink>();
            componentMapper.Register<DBlazor.CardImage, Bulma.CardImage>();
            componentMapper.Register<DBlazor.CardSubtitle, Bulma.CardSubtitle>();
            componentMapper.Register<DBlazor.CheckEdit, Bulma.CheckEdit>();
            componentMapper.Register<DBlazor.DateEdit, Bulma.DateEdit>();
            componentMapper.Register<DBlazor.DropdownDivider, Bulma.DropdownDivider>();
            componentMapper.Register<DBlazor.DropdownMenu, Bulma.DropdownMenu>();
            componentMapper.Register<DBlazor.DropdownToggle, Bulma.DropdownToggle>();
            componentMapper.Register<DBlazor.Field, Bulma.Field>();
            componentMapper.Register<DBlazor.FieldLabel, Bulma.FieldLabel>();
            componentMapper.Register<DBlazor.FieldHelp, Bulma.FieldHelp>();
            componentMapper.Register<DBlazor.FieldBody, Bulma.FieldBody>();
            componentMapper.Register<DBlazor.Fields, Bulma.Fields>();
            componentMapper.Register<DBlazor.FileEdit, Bulma.FileEdit>();
            componentMapper.Register<DBlazor.MemoEdit, Bulma.MemoEdit>();
            componentMapper.Register( typeof( DBlazor.SelectEdit<> ), typeof( Bulma.SelectEdit<> ) );
            componentMapper.Register<DBlazor.SimpleButton, Bulma.SimpleButton>();
            componentMapper.Register<DBlazor.Tabs, Bulma.Tabs>();
            componentMapper.Register<DBlazor.TextEdit, Bulma.TextEdit>();
            componentMapper.Register( typeof( DBlazor.NumericEdit<> ), typeof( Bulma.NumericEdit<> ) );

            return app;
        }
    }
}
