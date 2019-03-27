using Microsoft.AspNetCore.Components;

namespace DBlazor.Base
{
    public abstract class BaseAddons : BaseComponent
    {
        private IFluentColumn columnSize;

        [Parameter]
        protected IFluentColumn ColumnSize
        {
            get => columnSize;
            set
            {
                columnSize = value;

                Dirty();
                ClassMapper.Dirty();
            }
        }

        protected virtual bool ParentIsHorizontal => ParentField?.IsHorizontal == true;

        [CascadingParameter] protected BaseField ParentField { get; set; }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        protected override void RegisterClasses()
        {
            ClassMapper.Add(() => ClassProvider.Addons());

            base.RegisterClasses();
        }
    }
}
