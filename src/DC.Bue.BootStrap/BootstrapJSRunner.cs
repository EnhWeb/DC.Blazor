#region Using directives
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
#endregion

namespace DC.Bue.BootStrap
{
    public partial class BootStrapJSRunner : JSRunner
    {
        public BootStrapJSRunner( IJSRuntime runtime )
            : base( runtime )
        {
        }

        //public override Task<bool> ActivateDatePicker( string elementId )
        //{
        //    return JSRuntime.Current.InvokeAsync<bool>( $"DC.BueBootStrap.activateDatePicker", elementId );
        //}
    }
}
