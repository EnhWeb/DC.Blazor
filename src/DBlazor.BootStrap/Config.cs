using System;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DBlazor.BootStrap
{
    public static class Config
    {
        /// <summary>
        /// Adds a BootStrap providers and component mappings.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddBootStrapProviders( this IServiceCollection serviceCollection, Action<IClassProvider> configureClassProvider = null )
        {
            var classProvider = new BootStrapClassProvider();

            configureClassProvider?.Invoke( classProvider );

            serviceCollection.AddSingleton<IClassProvider>( classProvider );
            serviceCollection.AddSingleton<IStyleProvider, BootStrapStyleProvider>();
            serviceCollection.AddScoped<IJSRunner, BootStrapJSRunner>();
            serviceCollection.AddSingleton<IComponentMapper, ComponentMapper>();

            return serviceCollection;
        }

        /// <summary>
        /// Registers the custom rules for BootStrap components.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IComponentsApplicationBuilder UseBootStrapProviders( this IComponentsApplicationBuilder app )
        {
            var componentMapper = app.Services.GetRequiredService<IComponentMapper>();

            componentMapper.Register<DBlazor.Addon, BootStrap.Addon>();
            //componentMapper.Register<DBlazor.Addons, BootStrap.Addons>();
            componentMapper.Register<DBlazor.BarToggler, BootStrap.BarToggler>();
            componentMapper.Register<DBlazor.BarDropdown, BootStrap.BarDropdown>();
            componentMapper.Register<DBlazor.CardSubtitle, BootStrap.CardSubtitle>();
            componentMapper.Register<DBlazor.CloseButton, BootStrap.CloseButton>();
            componentMapper.Register<DBlazor.CheckEdit, BootStrap.CheckEdit>();
            //componentMapper.Register<DBlazor.DateEdit, BootStrap.DateEdit>();
            componentMapper.Register<DBlazor.Field, BootStrap.Field>();
            componentMapper.Register<DBlazor.FieldBody, BootStrap.FieldBody>();
            componentMapper.Register<DBlazor.FileEdit, BootStrap.FileEdit>();
            componentMapper.Register<DBlazor.ModalContent, BootStrap.ModalContent>();
            //componentMapper.Register<DBlazor.MemoEdit, BootStrap.MemoEdit>();
            //componentMapper.Register<DBlazor.SelectEdit, BootStrap.SelectEdit>();
            componentMapper.Register<DBlazor.SimpleButton, BootStrap.SimpleButton>();
            //componentMapper.Register<DBlazor.TextEdit, BootStrap.TextEdit>();

            return app;
        }
    }
}
