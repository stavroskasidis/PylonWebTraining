using Hercules.Libs.Web.Client.ControllerOptions;
using Hercules.Libs.Web.Client.Controllers;
using Poseidon.Libs.Web.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Web.Masters.Items
{
    [powAuthorizeActions(typeof(hewServicesAthenaAction))]
    public class hewDemoServicesAthenaController : hewBrowserController
    {
        protected override string BrowserDomain => "Hercules";

        protected override string BrowserName => "Demo.Services.Athena";

        protected override void SetPageOptions(hewPageOptionsBuilder builder)
        {
            builder.Title("Services Demo");
        }
    }
}
