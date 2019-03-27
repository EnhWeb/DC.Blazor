﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace DC.Bue.Bulma
{
    class BulmaStyleProvider : IStyleProvider
    {
        #region Modal

        public string ModalShow() => null;

        #endregion

        #region ModalBody

        public string ModalBodyMaxHeight( int maxHeight ) => $"max-height: {maxHeight}vh; overflow-y: auto;";

        #endregion

        #region ProgressBar

        public string ProgressBarValue( int value ) => $"width: {value}%";

        #endregion

        #region Layout

        public string Visibility( Visibility visibility ) => visibility == DC.Bue.Visibility.Never ? "display: none;" : null;

        #endregion
    }
}
