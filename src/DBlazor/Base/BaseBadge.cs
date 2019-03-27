using Microsoft.AspNetCore.Components;

namespace DBlazor.Base
{
    public abstract class BaseBadge : BaseComponent
    {
        private bool isPill;

        private Color color = Color.None;

        private string link;

        [Parameter]
        protected bool IsPill
        {
            get => isPill;
            set
            {
                isPill = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected Color Color
        {
            get => color;
            set
            {
                color = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected string Link
        {
            get => link;
            set
            {
                link = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add(() => ClassProvider.Badge())
                .If(() => ClassProvider.BadgeColor(Color), () => Color != Color.None)
                .If(() => ClassProvider.BadgePill(), () => IsPill);

            base.RegisterClasses();
        }
    }
}
