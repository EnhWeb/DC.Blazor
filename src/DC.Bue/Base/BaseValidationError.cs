﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace DC.Bue.Base
{
    public abstract class BaseValidationError : BaseComponent
    {
        #region Members

        private bool isTooltip;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .If( () => ClassProvider.ValidationError(), () => !IsTooltip )
                .If( () => ClassProvider.ValidationErrorTooltip(), () => IsTooltip );

            base.RegisterClasses();
        }

        protected override void OnInit()
        {
            if ( ParentValidation != null )
            {
                ParentValidation.Validated += OnValidated;
            }

            base.OnInit();
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( ParentValidation != null )
                {
                    ParentValidation.Validated -= OnValidated;
                }
            }

            base.Dispose( disposing );
        }

        private void OnValidated( ValidatedEventArgs e )
        {
            ErrorText = e.ErrorText;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Custom error type that will override default content.
        /// </summary>
        protected string ErrorText { get; set; }

        /// <summary>
        /// Shows the tooltip instead of label.
        /// </summary>
        [Parameter]
        protected bool IsTooltip
        {
            get => isTooltip;
            set
            {
                isTooltip = value;

                ClassMapper.Dirty();
            }
        }

        [CascadingParameter] protected BaseValidation ParentValidation { get; set; }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
