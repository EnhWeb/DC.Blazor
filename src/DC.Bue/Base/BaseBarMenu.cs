﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace DC.Bue.Base
{
    public abstract class BaseBarMenu : BaseComponent
    {
        #region Members

        private bool isOpen;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.BarMenu() )
                .If( () => ClassProvider.BarMenuShow(), () => IsOpen );

            base.RegisterClasses();
        }

        public void Toggle()
        {
            IsOpen = !IsOpen;
            Toggled?.Invoke( IsOpen );

            StateHasChanged();
        }

        #endregion

        #region Properties

        [Parameter]
        protected bool IsOpen
        {
            get => isOpen;
            set
            {
                isOpen = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter] protected Action<bool> Toggled { get; set; }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
