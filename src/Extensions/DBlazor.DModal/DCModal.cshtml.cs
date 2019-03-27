using DBlazor.DModal.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace DBlazor.DModal
{
    public class DCModalBase : ComponentBase, IDisposable
    {
        [Inject] private IModalService ModalService { get; set; }

        protected bool IsVisible { get; set; }

        protected string Title { get; set; }

        protected RenderFragment Content { get; set; }

        protected ModalParameters Parameters { get; set; }

        protected override void OnInit()
        {
            ((ModalService)ModalService).OnShow += ShowModal;
            ModalService.OnClose += CloseModal;
        }

        public void ShowModal(string title, RenderFragment content, ModalParameters parameters)
        {
            Title = title;
            Content = content;
            Parameters = parameters;

            IsVisible = true;
            StateHasChanged();
        }

        public void CloseModal()
        {
            IsVisible = false;
            Title = "";
            Content = null;

            StateHasChanged();
        }

        public void Dispose()
        {
            ((ModalService)ModalService).OnShow -= ShowModal;
            ModalService.OnClose -= CloseModal;
        }
    }
}