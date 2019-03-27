﻿using Microsoft.AspNetCore.Components;
using System;

namespace DBlazor.Modal.Services
{
    public class ModalService : IModalService
    {
        public event Action OnClose;

        internal event Action<string, RenderFragment, ModalParameters> OnShow;

        public void Show(string title, Type contentType)
        {
            Show(title, contentType, new ModalParameters());
        }

        public void Show(string title, Type contentType, ModalParameters parameters)
        {
            if (!typeof(ComponentBase).IsAssignableFrom(contentType))
            {
                throw new ArgumentException($"{contentType.FullName}必须是Blazor组件");
            }

            var content = new RenderFragment(x =>
            {
                x.OpenComponent(1, contentType);
                x.CloseComponent();
            });

            OnShow?.Invoke(title, content, parameters);
        }

        public void Close()
        {
            OnClose?.Invoke();
        }
    }
}
