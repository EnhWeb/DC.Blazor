#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace DC.Bue.BootStrap
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

            componentMapper.Register<DC.Bue.Addon, BootStrap.Addon>();
            //componentMapper.Register<DC.Bue.Addons, BootStrap.Addons>();
            componentMapper.Register<DC.Bue.BarToggler, BootStrap.BarToggler>();
            componentMapper.Register<DC.Bue.BarDropdown, BootStrap.BarDropdown>();
            componentMapper.Register<DC.Bue.CardSubtitle, BootStrap.CardSubtitle>();
            componentMapper.Register<DC.Bue.CloseButton, BootStrap.CloseButton>();
            componentMapper.Register<DC.Bue.CheckEdit, BootStrap.CheckEdit>();
            //componentMapper.Register<DC.Bue.DateEdit, BootStrap.DateEdit>();
            componentMapper.Register<DC.Bue.Field, BootStrap.Field>();
            componentMapper.Register<DC.Bue.FieldBody, BootStrap.FieldBody>();
            componentMapper.Register<DC.Bue.FileEdit, BootStrap.FileEdit>();
            componentMapper.Register<DC.Bue.ModalContent, BootStrap.ModalContent>();
            //componentMapper.Register<DC.Bue.MemoEdit, BootStrap.MemoEdit>();
            //componentMapper.Register<DC.Bue.SelectEdit, BootStrap.SelectEdit>();
            componentMapper.Register<DC.Bue.SimpleButton, BootStrap.SimpleButton>();
            //componentMapper.Register<DC.Bue.TextEdit, BootStrap.TextEdit>();

            return app;
        }
    }
}
