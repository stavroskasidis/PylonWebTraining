using Hercules.Libs.Base;
using Hercules.Libs.Web.UI;
using Hercules.Obj.Web.STH.DataObjectProxies.Item;
using Poseidon.Libs.Base.SqlOM;
using Poseidon.Libs.Web.Base;
using Poseidon.Libs.Web.UI;
using Poseidon.Libs.Web.UI.Components.Grids;
using Reeb.SqlOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Obj.Web.Masters.Items
{
    [powSchemaView("Hercules", "Demo.Services.Athena.Default")]
    public class hewDemoServicesAthenaDefinitionDefault : hewBrowserDefinition
    {
        public override string BaseTableIDColumnName => "ID";

        public override string DescriptionField => "heName";

        protected override void BuildGrid(powBrowserGridBuilder grid)
        {
            grid.AddColumn(hewResources.sCode, "heCode", colWidth: 250);
            grid.AddColumn(hewResources.sName, "heName", colWidth: 400);
            grid.AddColumn(hewResources.sMeasurementUnit, "AMUNAME");
            grid.AddColumn(hewResources.sVATClass, "VTCLNAME");
            grid.AddColumn(hewResources.sIaccName, "IaccName");
            grid.AddColumn(hewResources.sActive, "heActive", 155, powColumnType.CheckBox);
            grid.AddSorting("heCode", powGridSortFieldDirection.Ascending);
        }

        protected override poSelectQuery BuildQuery()
        {
            var selQuery = new poSelectQuery("heItems");
            selQuery.AddColumn("heID", selQuery.BaseTable, "ID");
            selQuery.AddColumn("heCode", selQuery.BaseTable, "heCode");
            selQuery.AddColumn("heName", selQuery.BaseTable, "heName");
            selQuery.AddColumns("heFactoryCode", "heSeasID", "heAMsntID", "heAuxiliaryCode", "heDetailedDescr", "heClassification", "heKind",
                                "heCompID", "heActive", "heNameSoundex", "heRefNumber", "heIaccID", "heProductionCatID", "heBlockSales", "heBlockPurchases", "heBlockWarehouses", "hePartInStockControl"
                                , "heSalInvAttrSpPrice", "hePurInvAttrSpPrice", "heCat01ID", "heCat02ID", "HECALCFROMVALUE",
                                "heRetailPrice", "heWholeSalesPrice");
            selQuery.AddColumns("heSplrID", "heType");

            selQuery.WherePhrase.Terms.Add(WhereTerm.CreateCompare(SqlExpression.Field("heCompID", selQuery.FromClause.BaseTable), selQuery.ParameterValue(AppContext.GetService<heSystemParams>().CurrentCompanyID), CompareOperator.Equal));
            selQuery.WherePhrase.Terms.Add(WhereTerm.CreateCompare(SqlExpression.Field("heType", selQuery.FromClause.BaseTable), selQuery.ParameterValue(Convert.ToInt16(hewItemsDataObjectProxy.ItemTypeEnum.Service)), CompareOperator.Equal));

            selQuery.AddEnumColumn(AppContext, selQuery.FromClause.BaseTable, "Hercules;heItems;heKind");
            selQuery.AddEnumColumn(AppContext, selQuery.FromClause.BaseTable, "Hercules;heItems;heClassification");

            var AMesUnits = FromTerm.Table("heMeasurementUnits", "MU1");
            selQuery.AddColumn("heName", AMesUnits, "AMUNAME");
            selQuery.FromClause.Join(JoinType.Inner, selQuery.BaseTable, AMesUnits, "heAMsntID", "heID");

            var vats = FromTerm.Table("heVATClasses", "Vats");
            selQuery.AddColumn("heName", vats, "VTCLNAME");
            selQuery.FromClause.Join(JoinType.Inner, selQuery.FromClause.BaseTable, vats, "heVtclID", "heID");

            var iaccs = FromTerm.Table("heItemAccCategories", "Iacc");
            selQuery.AddColumn("heName", iaccs, "IaccName");
            selQuery.FromClause.Join(JoinType.Left, selQuery.FromClause.BaseTable, iaccs, "heIaccID", "heID");

            return selQuery;
        }
    }
}
