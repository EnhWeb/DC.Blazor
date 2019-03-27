using Microsoft.AspNetCore.Components;

namespace DC.Bue.Base
{
    public abstract class BaseIcon : BaseComponent
    {
        private object name;

        /// <summary>
        /// 注册样式类
        /// </summary>
        protected override void RegisterClasses()
        {
            ClassMapper
                .Add(() => IconProvider.Icon())
                .If(() => IconProvider.Get((IconName)Name), () => !IconProvider.IconNameAsContent && Name != null && Name is IconName)
                .If(() => IconProvider.Get((string)Name), () => !IconProvider.IconNameAsContent && Name != null && Name is string);

            base.RegisterClasses();
        }

        [Inject] protected IIconProvider IconProvider { get; set; }

        [Parameter] protected object Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

                ClassMapper.Dirty();
            }
        }
    }
}
