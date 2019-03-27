using Microsoft.JSInterop;

namespace DC.Bue.Providers
{
    public abstract class JSRunner : IJSRunner
    {
        protected readonly IJSRuntime runtime;

        public JSRunner(IJSRuntime runtime)
        {
            this.runtime = runtime;
        }

    }
}
