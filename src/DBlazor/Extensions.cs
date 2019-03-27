﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace DBlazor
{
    public static class Extensions
    {
        public static string ToButtonTypeString( this ButtonType buttonType )
        {
            switch ( buttonType )
            {
                case ButtonType.Button:
                    return "button";
                case ButtonType.Submit:
                    return "submit";
                case ButtonType.Reset:
                    return "reset";
                default:
                    return null;
            }
        }

        public static string ToTextRoleString( this TextRole textRole )
        {
            switch ( textRole )
            {
                case TextRole.Email:
                    return "email";
                case TextRole.Password:
                    return "password";
                case TextRole.Url:
                    return "url";
                default:
                    return "text";
            }
        }

        public static T GetAndRemove<T>( this IDictionary<string, object> values, string key )
        {
            if ( values.TryGetValue( key, out var value ) )
            {
                values.Remove( key );
                return (T)value;
            }
            else
            {
                return default;
            }
        }
    }
}
