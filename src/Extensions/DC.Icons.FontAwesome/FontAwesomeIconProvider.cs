using DC.Bue;
using DC.Bue.Providers;
using System.Collections.Generic;

namespace DC.Icons.FontAwesome
{
    class FontAwesomeIconProvider : BaseIconProvider
    {
        /// <summary>
        /// 预设图标名称对应的名称
        /// </summary>
        private static Dictionary<IconName, string> names = new Dictionary<IconName, string>
        {
            { IconName.New, "fa-plus" },
            { IconName.Edit, "fa-edit" },
            { IconName.Save, "fa-save" },
            { IconName.Cancel, "fa-ban" },
            { IconName.Delete, "fa-trash" },
            { IconName.Clear, "fa-eraser" },
            { IconName.Search, "fa-search" },
            { IconName.ClearSearch, "fa-minus-circle" },
            { IconName.Phone, "fa-phone" },
            { IconName.Smartphone, "fa-mobile" },
            { IconName.Mail, "fa-envelope" },
            { IconName.Person, "fa-user" },
            { IconName.Lock, "fa-lock" },
            { IconName.MoreHorizontal, "fa-ellipsis-h" },
            { IconName.MoreVertical, "fa-ellipsis-v" },
            { IconName.ExpandMore, "fa-chevron-down" },
            { IconName.ExpandLess, "fa-chevron-up" },
            { IconName.SliderHorizontal, "fa-sliders-h" },
            { IconName.SliderVertical, "fa-sliders-v" },
            { IconName.Dashboard, "fa-columns" }, // 找到更好
        };

        /// <summary>
        /// 获取预定义的图标名称集合标识。
        /// </summary>
        /// <returns></returns>
        public override string Icon()
        {
            return "fas";
        }

        /// <summary>
        /// 按预定义的图标类型获取图标名称。
        /// </summary>
        /// <param name="iconName">图标名称</param>
        /// <returns></returns>
        public override string Get(IconName iconName)
        {
            names.TryGetValue(iconName, out var name);

            return name;
        }

        /// <summary>
        /// 覆盖预定义的图标名称。
        /// </summary>
        /// <param name="name">图标名称</param>
        /// <param name="newName">对应的图标新名称</param>
        public override void Set(IconName name, string newName)
        {
            names[name] = newName;
        }

        public override bool IconNameAsContent => false;
    }
}
