#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DBlazor.Material
{
    public class MaterialClassProvider : BootStrap.BootStrapClassProvider
    {
        public override string TabPanel() => "tab-pane fade";

        public override string Nav() => "nav nav-tabs-material";

        public override string Bar() => "navbar navbar-full";

        public override string Provider => "Material";
    }
}
