using Poseidon.Libs.Web.Client;
using Poseidon.Libs.Web.UI;
using Poseidon.Libs.Web.UI.Client.ViewEngine.SystemViews;
using Poseidon.Libs.Web.UI.Client.ViewEngine.ViewModels;
using Poseidon.Libs.Web.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Web.Masters.Items
{
    public class hewDemoServicesAthenaQuickFilters : powQuickFiltersPartial
    {
        protected override void BuildQuickFiltersForm(powFormBuilder<powBrowserQuickFiltersViewModel> form)
        {
            form.AddPanel("ItemsFilters", panel =>
            {
                panel.HeaderCaption(hewResources.sQuickFilters);
                panel.AddStackLayout(powStackLayoutOrientation.Vertical, stack =>
                {
                    stack.AddTextBox("Name").Caption(hewResources.sName);
                });
            });
        }
    }
}
