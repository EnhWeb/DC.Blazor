﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace DC.Bue.Providers
{
    class EmptyStyleProvider : IStyleProvider
    {
        #region Modal

        public string ModalShow() => null;

        #endregion

        #region ModalBody

        public string ModalBodyMaxHeight( int maxHeight ) => null;

        #endregion

        #region ProgressBar

        public string ProgressBarValue( int value ) => null;

        #endregion

        #region Layout

        public string Visibility( Visibility visibility ) => null;

        #endregion
    }
}
