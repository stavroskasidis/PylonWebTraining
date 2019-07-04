using Hercules.Libs.Web.UI.Client.ViewModels;
using Poseidon.Libs.Web.UI;
using Poseidon.Libs.Web.UI.Client.ViewEngine.SystemViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.Libs.Web.UI.Client.SystemViews
{
    public class hewDemoIndex : powSystemBaseView<hewDemoIndexViewModel>
    {
        protected override void Build(powComponentBuilder<hewDemoIndexViewModel> builder)
        {
            this.RegisterFooterScriptEntryPoint("demoIndex", "hewClientScripts.DemoIndex");
            builder.AddForm(form =>
            {
                form.Id("mainForm");
                form.AddTableLayout(table =>
                {
                    table.AddRow(row =>
                    {
                        row.AddTextBoxFor(model => model.Description).Caption("Description");    //weight: 1  => 1/4
                        row.AddNumericTextBoxFor(model => model.Amount).Caption("Amount");       //weight: 1  =>  1/4
                        row.AddMasterLookUpFor(model => model.CustID).Caption("Customer")        //weight: 1  => 1/4
                            .Browser("Hercules", "Customers.Athena");
                        row.AddEmptyColumn();                                                    //weight: 1  => 1/4
                                                                                                 //Total:  4
                    });

                    table.AddRow(row =>
                    {
                        row.AddArrayLookUpFor(model => model.VtstID).Caption("Vat Status")
                           .Definition("Hercules", "VATStatusesArrayLookUpDataSource");
                        row.AddDateTimePickerFor(model => model.Date).Caption("Date")
                           .Id("DemoDatePicker");
                        row.AddDropDownListFor(model => model.NeedsDate).Caption("Needs Date")
                           .Id("NeedsDateDropdown")
                           .Events(e => e.Change("function() { demoIndex.OnNeedsDateChange(); }"))
                           .RemoteDataSource("GetNeedsDateEnum", "hewDemo")
                           .ValueField("Value")
                           .TextField("Text");
                    });

                    table.AddRow(row =>
                    {
                        row.AddEmptyColumn(11);
                        row.AddSwitchFor(model => model.Active).Caption("Active");
                    });
                });
            });
        }
    }
}
