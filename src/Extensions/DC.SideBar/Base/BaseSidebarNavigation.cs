﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC.Bue.Base;
using Microsoft.AspNetCore.Components;
#endregion

namespace DC.Bue.Sidebar.Base
{
    public abstract class BaseSidebarNavigation : BaseComponent
    {
        #region Members

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( "sidebar-nav" );

            base.RegisterClasses();
        }

        #endregion

        #region Properties

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}