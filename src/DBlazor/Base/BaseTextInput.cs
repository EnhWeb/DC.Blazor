﻿#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace DBlazor.Base
{
    /// <summary>
    /// Base component for inputs that are text-based.
    /// </summary>
    /// <typeparam name="TValue">Editable value type.</typeparam>
    public abstract class BaseTextInput<TValue> : BaseInputComponent<TValue>
    {
        #region Members

        private Color color;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.Text( IsPlaintext ) )
                .If( () => ClassProvider.TextColor( Color ), () => Color != Color.None )
                .If( () => ClassProvider.TextSize( Size ), () => Size != Size.None )
                .If( () => ClassProvider.TextValidation( ParentValidation?.Status ?? ValidationStatus.None ), () => ParentValidation?.Status != ValidationStatus.None );

            base.RegisterClasses();
        }

        protected void HandleOnChange( UIChangeEventArgs e )
        {
            if ( !Options.ChangeTextOnKeyPress )
            {
                HandleValue( e?.Value );
            }
        }

        protected void HandleOnInput( UIChangeEventArgs e )
        {
            if ( Options.ChangeTextOnKeyPress )
            {
                HandleValue( e?.Value );
            }
        }

        protected abstract void HandleValue( object value );

        #endregion

        #region Properties

        [Inject] protected DCOptions Options { get; set; }

        /// <summary>
        /// Sets the placeholder for the empty text.
        /// </summary>
        [Parameter] protected string Placeholder { get; set; }

        /// <summary>
        /// Sets the class to remove the default form field styling and preserve the correct margin and padding.
        /// </summary>
        [Parameter] protected bool IsPlaintext { get; set; }

        /// <summary>
        /// Sets the input text color.
        /// </summary>
        [Parameter]
        protected Color Color
        {
            get => color;
            set
            {
                color = value;

                Dirty();
                ClassMapper.Dirty();
            }
        }

        #endregion
    }
}
