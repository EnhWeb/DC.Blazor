using Microsoft.AspNetCore.Components;

namespace DBlazor.Base
{
    public abstract class BaseAddonLabel : BaseComponent
    {
        [Parameter] protected RenderFragment ChildContent { get; set; }

        protected override void RegisterClasses()
        {
            ClassMapper.Add(() => ClassProvider.AddonLabel());

            base.RegisterClasses();
        }
    }
}
