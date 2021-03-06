﻿using System;
using DBlazor.BootStrap;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DBlazor.Material
{
    public static class Config
    {
        public static IServiceCollection AddMaterialProviders( this IServiceCollection serviceCollection, Action<IClassProvider> configureClassProvider = null )
        {
            var classProvider = new MaterialClassProvider();

            configureClassProvider?.Invoke( classProvider );

            serviceCollection.AddSingleton<IClassProvider>( classProvider );
            serviceCollection.AddSingleton<IStyleProvider, MaterialStyleProvider>();
            serviceCollection.AddSingleton<IJSRunner, MaterialJSRunner>();
            serviceCollection.AddSingleton<IComponentMapper, ComponentMapper>();

            return serviceCollection;
        }

        /// <summary>
        /// Registers the custom rules for material components.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IComponentsApplicationBuilder UseMaterialProviders( this IComponentsApplicationBuilder app )
        {
            // same components as in bootstrap provider
            app.UseBootStrapProviders();

            return app;
        }
    }
}
