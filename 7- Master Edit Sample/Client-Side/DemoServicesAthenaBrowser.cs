using Poseidon.Libs.Base.SqlOM;
using Poseidon.Libs.Web.Base;
using Poseidon.Libs.Web.Base.Filtering;
using Poseidon.Libs.Web.UI;
using Reeb.SqlOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Obj.Web.Masters.Items
{
    [powSchemaBrowser("Hercules", "Demo.Services.Athena", "Hercules;heServices;default.Athena")]
    public class hewDemoServicesAthenaBrowser : powBrowser
    {
        public override string Title => "Demo Services";

        public override string EditController => "hewDemoServicesAthenaEdit";

        public override string BrowserController => "hewDemoServicesAthena";

        protected override void SetBrowserOptions(powBrowserOptionsBuilder options)
        {
            options.RegisterDefinition<hewDemoServicesAthenaDefinitionDefault>(hewResources.sDefault, true);
            options.SetLeftBarPartial("Hercules.ATH.Web.Masters.Items.hewDemoServicesAthenaQuickFilters");
        }

        public override List<powFilterField> RegisterQuickFilters(powRawQuickFiltersCollection rawQuickFilters)
        {
            var filtersList = base.RegisterQuickFilters(rawQuickFilters);
            if (!string.IsNullOrWhiteSpace(rawQuickFilters["Name"]))
            {
                filtersList.Add(new powFilterField("heName", rawQuickFilters["Name"], false));
            }
            return filtersList;
        }

        public override void HandleQuickFilters(poSelectQuery query, List<powFilterField> filterFields)
        {
            base.HandleQuickFilters(query, filterFields);
            foreach (var field in filterFields)
            {
                if (field.FieldName == "heName")
                {
                    var value = $"%{field.FieldValue}%";
                    query.WherePhrase.Terms.Add(WhereTerm.CreateCompare(SqlExpression.Field("heName", query.BaseTable), query.ParameterValue(value), CompareOperator.Like));
                }
            }
        }
    }
}
