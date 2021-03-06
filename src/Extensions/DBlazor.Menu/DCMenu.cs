﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Components.Routing;
using System;

namespace DBlazor.Menu
{
    public class DCMenu : ComponentBase
    {
        /// <summary>
        /// 菜单子内容
        /// </summary>
        [Parameter] RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 菜单构建器
        /// </summary>
        [Parameter] MenuBuilder MenuBuilder { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (ChildContent != null && MenuBuilder != null)
            {
                throw new InvalidOperationException($"不能同时使用菜单子内容和菜单构建器");
            }

            if (ChildContent != null)
            {
                BuildMenuFromMarkup(builder);
            }
            else if (MenuBuilder != null)
            {
                BuildMenuFromBuilder(builder);
            }
        }

        private void BuildMenuFromMarkup(RenderTreeBuilder builder)
        {
            var index = -1;

            builder.OpenElement(index++, "nav");
            builder.AddAttribute(index++, "role", "navigation");
            builder.AddAttribute(index++, "class", "dc-menu-container");
            builder.OpenElement(index++, "ul");
            builder.AddAttribute(index++, "class", "dc-menu");
            builder.AddContent(index++, ChildContent);
            builder.CloseElement();
            builder.CloseElement();
        }

        private void BuildMenuFromBuilder(RenderTreeBuilder builder)
        {
            var index = -1;
            var menuItems = MenuBuilder.Build(x => x.Position);

            builder.OpenElement(index++, "nav");
            builder.AddAttribute(index++, "role", "navigation");
            builder.AddAttribute(index++, "class", "dc-menu-container");
            builder.OpenElement(index++, "ul");
            builder.AddAttribute(index++, "class", "dc-menu");

            foreach (var item in menuItems)
            {
                if (item.IsSubMenu && item.IsVisible)
                {
                    index = BuildSubMenu(builder, index, item);
                }
                else if (!item.IsSubMenu && item.IsVisible)
                {
                    index = BuildMenuItem(builder, index, item);
                }
            }

            builder.CloseElement();
            builder.CloseElement();
        }

        private int BuildSubMenu(RenderTreeBuilder subMenuBuilder, int index, MenuItem item)
        {
            subMenuBuilder.OpenComponent<DCSubMenu>(index++);
            subMenuBuilder.AddAttribute(index++, "Header", item.Title);

            if (!item.IsEnabled)
            {
                subMenuBuilder.AddAttribute(index++, "disabled", "true");
            }

            subMenuBuilder.AddAttribute(index++, "ChildContent", (RenderFragment)((subMenuContentBuilder) =>
            {
                var subMenuItems = item.MenuItems.Build(x => x.Position);

                foreach (var subMenuItem in subMenuItems)
                {
                    index = BuildMenuItem(subMenuContentBuilder, index, subMenuItem);
                }
            }));

            subMenuBuilder.CloseComponent();

            return index;
        }

        private int BuildMenuItem(RenderTreeBuilder menuItemBuilder, int index, MenuItem item)
        {
            menuItemBuilder.OpenComponent<DCMenuItem>(index++);

            if (item.IsVisible)
            {
                if (item.IsEnabled)
                {
                    menuItemBuilder.AddAttribute(index++, "ChildContent", (RenderFragment)((menuItemContentBuilder) => 
                    {
                        menuItemContentBuilder.OpenComponent<NavLink>(index++);
                        menuItemContentBuilder.AddAttribute(index++, "href", item.Link);

                        if (item.Link?.Trim() == "/")
                        {
                            menuItemContentBuilder.AddAttribute(index++, "Match", NavLinkMatch.All);
                        }

                        menuItemContentBuilder.AddAttribute(index++, "ChildContent", (RenderFragment)((navLinkContentBuilder) => 
                        {
                            navLinkContentBuilder.AddContent(index++, item.Title);
                        }));

                        menuItemContentBuilder.AddContent(index++, item.Title);

                        menuItemContentBuilder.CloseComponent();
                    }));
                }
                else
                {
                    menuItemBuilder.AddAttribute(index++, "IsEnabled", item.IsEnabled);
                    menuItemBuilder.AddAttribute(index++, "ChildContent", (RenderFragment)((menuItemContentBuilder) =>
                    {
                        menuItemContentBuilder.AddContent(index++, item.Title);
                    }));
                }
            }
            else
            {
                menuItemBuilder.AddAttribute(index++, "IsVisible", item.IsVisible);
                menuItemBuilder.AddAttribute(index++, "ChildContent", (RenderFragment)((menuItemContentBuilder) =>
                {
                    menuItemContentBuilder.AddContent(index++, item.Title);
                }));
            }

            menuItemBuilder.CloseComponent();

            return index;
        }
    }
}
