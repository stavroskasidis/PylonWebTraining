using Hercules.Libs.Web.Server.Views;
using Hercules.Obj.Web.FIN.DataObjectProxies.CreditCards;
using Poseidon.Libs.Web.Base;
using Poseidon.Libs.Web.UI;
using Poseidon.Libs.Web.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Obj.Web.Arrays
{
    [powSchemaView("Hercules", "Demo.CreditCards.Athena.Edit")]
    public class hewDemoCreditCardsAthenaEdit :
        hewArrayEditGridWithExternalEditorsView<hewCreditCardsDataObjectProxy>
    {
        protected override string Name => "CreditCards";
        protected override string Controller => "hewDemoCreditCardsAthenaEdit";
        protected override void BuildTable(powTableLayoutBuilder<hewCreditCardsDataObjectProxy> tableBuilder)
        {
            tableBuilder.AddRow(row =>
            {
                row.AddTextBoxFor(model => model.Code).Caption(hewResources.sCode);
            });

            tableBuilder.AddRow(row =>
            {
                row.AddTextBoxFor(model => model.Name).Caption(hewResources.sName);
            });

            tableBuilder.AddRow(row =>
            {
                row.AddMasterLookUpFor(model => model.BankID)
                        .Caption(hewResources.sBank1)
                        .Browser("Hercules", "BanksAthena");
            });

            tableBuilder.AddRow(row =>
            {
                row.AddSwitchFor(model => model.Active).Caption(hewResources.sActive);
            });

            tableBuilder.AddRow(row =>
            {
                row.AddPanel("AccountingPanel", panel =>
                {
                    panel.HeaderCaption(hewResources.sAccounting);
                    panel.AddStackLayout(powStackLayoutOrientation.Vertical, stack =>
                    {
                        stack.AddTextBoxFor(p => p.AccPrefix01).Caption(hewResources.sPrefix01);
                    });
                });
            });
        }
    }
}
