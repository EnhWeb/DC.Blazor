#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC.Bue.Base;
using Microsoft.AspNetCore.Components;
#endregion

namespace DC.Bue.Charts.Base
{
    public abstract class BasePolarAreaChart<TItem> : BaseChart<PolarAreaChartDataset<TItem>, TItem, PolarAreaChartOptions>
    {
        #region Members

        #endregion

        #region Methods

        #endregion

        #region Properties

        protected override ChartType Type { get; set; } = ChartType.PolarArea;

        #endregion
    }
}
