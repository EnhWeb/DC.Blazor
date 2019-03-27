#region Using directives
using Microsoft.JSInterop;
using System.Threading.Tasks;
#endregion

namespace DBlazor.Material
{
    public partial class MaterialJSRunner : DBlazor.JSRunner
    {
        public MaterialJSRunner( IJSRuntime runtime )
               : base( runtime )
        {
        }

        public override Task<bool> ActivateDatePicker( string elementId, string formatSubmit )
        {
            return runtime.InvokeAsync<bool>( $"DBlazorMaterial.activateDatePicker", elementId, formatSubmit );
        }
    }
}
