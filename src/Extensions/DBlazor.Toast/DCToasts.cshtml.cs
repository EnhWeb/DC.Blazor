// Copyright (c) ��������΢������Ƽ����޹�˾. All Rights Reserved.
// ���� QQ��2505111990 ΢�ţ�i230760 qqȺ:774046050 ����:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using DBlazor.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Timers;

namespace DBlazor.Toast
{
    public class DCToastsBase : ComponentBase
    {
        [Inject] private IToastService ToastService { get; set; }

        protected Dictionary<Guid, RenderFragment> ToastList { get; set; } = new Dictionary<Guid, RenderFragment>();

        protected override void OnInit()
        {
            ToastService.OnShow += ShowToast;
        }

        public void RemoveToast(Guid toastId)
        {
            ToastList.Remove(toastId);

            StateHasChanged();
        }

        private ToastSettings BuildToastSettings(ToastLevel level, string message, string heading)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Info" : heading, message, "dc-toast-info", "");

                case ToastLevel.Success:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Success" : heading, message, "dc-toast-success", "");

                case ToastLevel.Warning:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Warning" : heading, message, "dc-toast-warning", "");

                case ToastLevel.Error:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Error" : heading, message, "dc-toast-error", "");
            }

            throw new InvalidOperationException();
        }

        private void ShowToast(ToastLevel level, string message, string heading)
        {
            var settings = BuildToastSettings(level, message, heading);
            var toastId = Guid.NewGuid();
            var toast = new RenderFragment(b =>
            {
                b.OpenComponent<DCToast>(0);
                b.AddAttribute(1, "ToastSettings", settings);
                b.AddAttribute(2, "ToastId", toastId);
                b.CloseComponent();
            });

            ToastList.Add(toastId, toast);

            var toastTimer = new Timer(5000);
            toastTimer.Elapsed += (sender, args) => { RemoveToast(toastId); };
            toastTimer.AutoReset = false;
            toastTimer.Start();

            StateHasChanged();
        }
    }
}