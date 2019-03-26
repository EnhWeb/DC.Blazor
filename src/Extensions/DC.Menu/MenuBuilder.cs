using System;
using System.Collections.Generic;
using System.Linq;

namespace DC.Menu
{
    /// <summary>
    /// 菜单构建器
    /// </summary>
    public class MenuBuilder
    {
        /// <summary>
        /// 菜单集合
        /// </summary>
        private List<MenuItem> _menuItems;

        /// <summary>
        /// 初始化
        /// </summary>
        public MenuBuilder()
        {
            _menuItems = new List<MenuItem>();
        }

        public MenuBuilder AddItem(int position, string title, string link, bool IsVisible = true, bool IsEnabled = true)
        {
            var menuItem = new MenuItem();
            menuItem.Position = position;
            menuItem.Title = title;
            menuItem.Link = link;
            menuItem.IsSubMenu = false;
            menuItem.IsVisible = IsVisible;
            menuItem.IsEnabled = IsEnabled;

            _menuItems.Add(menuItem);

            return this;
        }

        public MenuBuilder AddSubMenu(int position, string title, MenuBuilder menuItems, bool IsVisible = true, bool IsEnabled = true)
        {
            var menuItem = new MenuItem();
            menuItem.Position = position;
            menuItem.Title = title;
            menuItem.IsSubMenu = true;
            menuItem.MenuItems = menuItems;
            menuItem.IsVisible = IsVisible;
            menuItem.IsEnabled = IsEnabled;

            _menuItems.Add(menuItem);

            return this;
        }

        /// <summary>
        /// 菜单排序
        /// </summary>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        internal List<MenuItem> Build(Func<MenuItem, int> orderBy)
        {
            var menuItems = _menuItems.OrderBy(orderBy);

            return menuItems.ToList();
        }

    }

    /// <summary>
    /// 菜单项
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// 菜单排序
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 菜单链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 子菜单项
        /// </summary>
        public MenuBuilder MenuItems { get; set; }

        /// <summary>
        /// 是否上级菜单
        /// </summary>
        public bool IsSubMenu { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
