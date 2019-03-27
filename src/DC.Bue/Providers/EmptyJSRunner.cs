using Microsoft.JSInterop;

namespace DC.Bue.Providers
{
    class EmptyJSRunner : JSRunner
    {
        public EmptyJSRunner(IJSRuntime runtime)
            : base(runtime)
        {

        }
    }
}
