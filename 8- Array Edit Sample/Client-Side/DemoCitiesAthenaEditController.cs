using Hercules.Libs.Web.Client.ControllerOptions;
using Hercules.Libs.Web.Client.Controllers;
using Hercules.Obj.Web.INF.DataObjectProxies.Geography;
using Poseidon.Libs.Web.Base.ViewModels;
using Poseidon.Libs.Web.Client;
using Poseidon.Libs.Web.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Web.Arrays.Miscellaneous
{
    [powAuthorizeActions(typeof(hewCitiesAthenaAction))]
    public class hewDemoCitiesAthenaEditController : hewArrayEditCodeNameController<hewCitiesDataObjectProxy, powArrayEditViewModel>
    {
        protected override string Name => "Cities";
        protected override string ViewName => "Demo.Cities.Athena.Edit";
        protected override void SetPageOptions(hewPageOptionsBuilder builder)
        {
            builder.Title(hewResources.sCities);
        }

        protected override OperationResult UpdateExistingObjectValues(hewCitiesDataObjectProxy oldValues, hewCitiesDataObjectProxy newValues)
        {
            oldValues.PrfcID = newValues.PrfcID;
            oldValues.MncpID = newValues.MncpID;
            return base.UpdateExistingObjectValues(oldValues, newValues);
        }
    }
}
