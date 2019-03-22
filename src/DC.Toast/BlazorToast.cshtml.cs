using Microsoft.AspNetCore.Components;
using System;

namespace DC.Toast
{
    public class BlazorToastBase : ComponentBase
    {
        [Parameter] protected Guid ToastId { get; set; }

        [Parameter] protected ToastSettings ToastSettings { get; set; }

        [CascadingParameter] private BlazorToasts ToastsContainer { get; set; }

        protected void HideToast()
        {
            ToastsContainer.RemoveToast(ToastId);
        }
    }
}