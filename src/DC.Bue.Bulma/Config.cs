#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace DC.Bue.Bulma
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

            componentMapper.Register<DC.Bue.Addons, Bulma.Addons>();
            componentMapper.Register<DC.Bue.BarToggler, Bulma.BarToggler>();
            componentMapper.Register<DC.Bue.BarDropdown, Bulma.BarDropdown>();
            componentMapper.Register<DC.Bue.Breadcrumb, Bulma.Breadcrumb>();
            componentMapper.Register<DC.Bue.BreadcrumbLink, Bulma.BreadcrumbLink>();
            componentMapper.Register<DC.Bue.CardImage, Bulma.CardImage>();
            componentMapper.Register<DC.Bue.CardSubtitle, Bulma.CardSubtitle>();
            componentMapper.Register<DC.Bue.CheckEdit, Bulma.CheckEdit>();
            componentMapper.Register<DC.Bue.DateEdit, Bulma.DateEdit>();
            componentMapper.Register<DC.Bue.DropdownDivider, Bulma.DropdownDivider>();
            componentMapper.Register<DC.Bue.DropdownMenu, Bulma.DropdownMenu>();
            componentMapper.Register<DC.Bue.DropdownToggle, Bulma.DropdownToggle>();
            componentMapper.Register<DC.Bue.Field, Bulma.Field>();
            componentMapper.Register<DC.Bue.FieldLabel, Bulma.FieldLabel>();
            componentMapper.Register<DC.Bue.FieldHelp, Bulma.FieldHelp>();
            componentMapper.Register<DC.Bue.FieldBody, Bulma.FieldBody>();
            componentMapper.Register<DC.Bue.Fields, Bulma.Fields>();
            componentMapper.Register<DC.Bue.FileEdit, Bulma.FileEdit>();
            componentMapper.Register<DC.Bue.MemoEdit, Bulma.MemoEdit>();
            componentMapper.Register( typeof( DC.Bue.SelectEdit<> ), typeof( Bulma.SelectEdit<> ) );
            componentMapper.Register<DC.Bue.SimpleButton, Bulma.SimpleButton>();
            componentMapper.Register<DC.Bue.Tabs, Bulma.Tabs>();
            componentMapper.Register<DC.Bue.TextEdit, Bulma.TextEdit>();
            componentMapper.Register( typeof( DC.Bue.NumericEdit<> ), typeof( Bulma.NumericEdit<> ) );

            return app;
        }
    }
}
