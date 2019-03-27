#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBlazor.Base;
using Microsoft.AspNetCore.Components;
#endregion

namespace DBlazor.Charts.Base
{
    public abstract class BaseDoughnutChart<TItem> : BaseChart<DoughnutChartDataset<TItem>, TItem, DoughnutChartOptions>
    {
        #region Members

        #endregion

        #region Methods

        #endregion

        #region Properties

        protected override ChartType Type { get; set; } = ChartType.Doughnut;

        #endregion
    }
}
