using Microsoft.AspNetCore.Components;

namespace DBlazor.Base
{
    public abstract class BaseAlert : BaseComponent
    {
        private bool isDismisable;

        private bool isShow;

        private Color color = Color.None;

        [Parameter]
        protected bool IsDismisable
        {
            get => isDismisable;
            set
            {
                isDismisable = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected bool IsShow
        {
            get => isShow;
            set
            {
                isShow = value;

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

        [Parameter] protected RenderFragment ChildContent { get; set; }

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add(() => ClassProvider.Alert())
                .If(() => ClassProvider.AlertColor(Color), () => Color != Color.None)
                .If(() => ClassProvider.AlertDismisable(), () => IsDismisable)
                .If(() => ClassProvider.Fade(), () => IsDismisable)
                .If(() => ClassProvider.Show(), () => IsDismisable && IsShow);

            base.RegisterClasses();
        }

        public void Show()
        {
            IsShow = true;
            StateHasChanged();
        }

        public void Hide()
        {
            IsShow = false;
            StateHasChanged();
        }

        public void Toggle()
        {
            IsShow = !IsShow;
            StateHasChanged();
        }
    }
}
