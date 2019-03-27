#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace DBlazor.Bulma.BulmaBase
{
    public abstract class BaseBulmaFieldBody : DBlazor.Base.BaseFieldBody
    {
        #region Members

        #endregion

        #region Methods

        #endregion

        #region Properties

        protected override bool UseColumnSizes => false; // Bulma does not support column sizes on fields.

        #endregion
    }
}
