﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace DBlazor.Base
{
    public abstract class BaseFigure : BaseComponent
    {
        #region Members

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.Figure() );

            base.RegisterClasses();
        }

        #endregion

        #region Properties

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
