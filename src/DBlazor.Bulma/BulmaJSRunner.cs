#region Using directives
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
#endregion

namespace DBlazor.Bulma
{
    public partial class BulmaJSRunner : DBlazor.JSRunner
    {
        public BulmaJSRunner( IJSRuntime runtime )
            : base( runtime )
        {

        }

        //public override Task<bool> ActivateDatePicker( string elementId, string formatSubmit )
        //{
        //    Console.WriteLine( "Bulma date not implemented." );
        //    return Task.FromResult( true );
        //}
    }
}
