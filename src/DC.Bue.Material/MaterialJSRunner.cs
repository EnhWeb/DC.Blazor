#region Using directives
using Microsoft.JSInterop;
using System.Threading.Tasks;
#endregion

namespace DC.Bue.Material
{
    public partial class MaterialJSRunner : DC.Bue.JSRunner
    {
        public MaterialJSRunner( IJSRuntime runtime )
               : base( runtime )
        {
        }

        public override Task<bool> ActivateDatePicker( string elementId, string formatSubmit )
        {
            return runtime.InvokeAsync<bool>( $"DC.BueMaterial.activateDatePicker", elementId, formatSubmit );
        }
    }
}
