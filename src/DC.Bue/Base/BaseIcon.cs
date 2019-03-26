using Microsoft.AspNetCore.Components;

namespace DC.Bue.Base
{
    public abstract class BaseIcon : BaseComponent
    {
        private object name;

        [Inject] IIconProvider IconProvider { get; set; }
    }
}
