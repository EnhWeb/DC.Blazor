using Microsoft.AspNetCore.Components;

namespace DC.Bue.Base
{
    public abstract class BaseAddon : BaseComponent
    {
        private AddonType addonType = AddonType.Body;

        [Parameter]
        protected AddonType AddonType
        {
            get => addonType;
            set
            {
                addonType = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        protected override void RegisterClasses()
        {
            ClassMapper.Add(() => ClassProvider.Addon(AddonType));

            base.RegisterClasses();
        }
    }
}
