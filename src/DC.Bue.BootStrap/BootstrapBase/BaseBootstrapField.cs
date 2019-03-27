#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace DC.Bue.BootStrap.BootStrapBase
{
    public abstract class BaseBootStrapField : DC.Bue.Base.BaseField
    {
        #region Members

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .If( () => ClassProvider.FieldColumn(), () => IsFields )
                .If( () => ColumnSize.Class( ClassProvider ), () => ColumnSize != null );

            base.RegisterClasses();
        }

        #endregion

        #region Properties

        #endregion
    }
}
