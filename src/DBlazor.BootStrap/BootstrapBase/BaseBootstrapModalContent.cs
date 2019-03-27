﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace DBlazor.BootStrap.BootStrapBase
{
    public abstract class BaseBootStrapModalContent : Base.BaseModalContent
    {
        #region Members

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            DialogClassMapper
                .Add( () => $"modal-dialog {ClassProvider.ModalSize( Size )}" )
                .If( () => ClassProvider.ModalContentCentered(), () => IsCentered );

            base.RegisterClasses();
        }

        protected override void Dirty()
        {
            DialogClassMapper.Dirty();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Dialog container classname.
        /// </summary>
        protected ClassMapper DialogClassMapper { get; } = new ClassMapper();

        #endregion
    }
}
