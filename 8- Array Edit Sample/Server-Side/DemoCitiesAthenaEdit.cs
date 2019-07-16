using Hercules.Libs.Web.Server.Views;
using Hercules.Obj.Web.INF.DataObjectProxies.Geography;
using Poseidon.Libs.Web.Base;
using Poseidon.Libs.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Obj.Web.Arrays.Miscellaneous
{
    [powSchemaView("Hercules", "Demo.Cities.Athena.Edit")]
    public class hewDemoCitiesAthenaEdit : hewArrayEditView<hewCitiesDataObjectProxy>
    {
        protected override string Name => "Cities";
        protected override string Controller => "hewDemoCitiesAthenaEdit";

        protected override void BuildGrid(powEditableGridBuilder<hewCitiesDataObjectProxy> gridBuilder)
        {
            base.BuildGrid(gridBuilder);
            gridBuilder.AddColumnFor(model => model.PrfcID, hewResources.sPrefecture, 
                col => col.SetArrayLookUpEditor("Hercules", "PrefecturesAthenaArrayLookUpDataSource"));
            gridBuilder.AddColumnFor(model => model.MncpID, hewResources.sMunicipality, 
                col => col.SetArrayLookUpEditor("Hercules", "MunicipalitiesAthenaArrayLookUpDataSource"));
        }
    }
}
