#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace DC.Bue
{
    public class BlazoriseOptions
    {
        /// <summary>
        /// If true the text in <see cref="TextEdit"/> will be changed after each key press.
        /// </summary>
        public bool ChangeTextOnKeyPress { get; set; } = true;
    }
}
