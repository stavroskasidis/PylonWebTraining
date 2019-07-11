using Hercules.Libs.Base;
using Hercules.Libs.Web.Base.DataObjectProxies;
using Hercules.Libs.Web.Server.Views;
using Hercules.Obj.Web.STH.DataObjectProxies.Item;
using Poseidon.Libs.Web.Base;
using Poseidon.Libs.Web.UI;
using Poseidon.Libs.Web.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Obj.Web.Masters.Items
{
    [powSchemaView("Hercules", "Demo.Services.Athena.Edit")]
    public class hewDemoServicesAthenaEdit : hewMasterEditView<hewItemsDataObjectProxy>
    {
        protected override string FormController => "hewDemoServicesAthenaEdit";

        private string GetPriceZoneDescription(int index)
        {

            var sp = AppContext.GetService<heSystemParams>();

            string descr = sp.PriceDiscount.ZoneDescription(index);
            if (string.IsNullOrEmpty(descr))
                switch (index)
                {
                    case 1: return hewResources.s1st;
                    case 2: return hewResources.s2nd;
                    case 3: return hewResources.s3rd;
                    case 4: return hewResources.s4th;
                    case 5: return hewResources.s5th;
                    case 6: return hewResources.s6th;
                    case 7: return hewResources.s7th;
                    case 8: return hewResources.s8th;
                    case 9: return hewResources.s9th;
                    default:
                        break;
                }
            return descr;
        }

        protected override void BuildForm(powFormBuilder<hewItemsDataObjectProxy> form)
        {
            RegisterFooterScriptEntryPoint("ServicesAthenaEdit", "hewClientScripts.ATH.Masters.Items.DemoServicesAthenaEdit");

            form.BindToObservable(true);
            form.Id("servicesEditForm");
            form.AddTableLayout(table =>
            {
                table.AddRow(row =>
                {
                    row.AddMasterCodeTextBoxFor(model => model.Code).CodeProvider("HESERVICES").Caption(hewResources.sCode);
                    row.AddTextBoxFor(model => model.Name).Caption(hewResources.sName);
                });
                table.AddRow(row =>
                {
                    row.AddTextBoxFor(model => model.RefNumber).Caption(hewResources.sRefNumber).ReadOnly(true);
                });
                table.AddRow(tabRow =>
                {
                    tabRow.AddTabStrip(tabStrip =>
                    {
                        tabStrip.AddTab(tab =>
                        {
                            tab.Caption(hewResources.sBasicInfo);
                            tab.Selected(true);
                            tab.AddStackLayout(powStackLayoutOrientation.Horizontal, stack =>
                            {
                                stack.AddTableLayout(tabTable =>
                                {
                                    tabTable.LayoutWeight(2);
                                    tabTable.AddRow(row =>
                                    {
                                        row.AddPanel("Categorization", panel =>
                                        {
                                            panel.HeaderCaption(hewResources.sCategorization);
                                            panel.AddTableLayout(panelTable =>
                                            {

                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddArrayLookUpFor(model => model.IaccID).Caption(hewResources.sAccountingCategory).Definition("Hercules", "ItemSrvAccCategoriesAthenaArrayLookUpDataSource");
                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddArrayLookUpFor(model => model.Kind).Caption(hewResources.sKindItem)
                                                      .Definition("Hercules", "ItemKindArrayLookUpDataSource").Enabled(false);
                                                    panelTableRow.AddEmptyColumn();
                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddArrayLookUpFor(model => model.AMsntID).Caption(hewResources.sMeasurementUnit).Definition("Hercules", "MeasurementUnitsAthenaArrayLookUpDataSource");
                                                    panelTableRow.AddArrayLookUpFor(model => model.VtclID).Caption(hewResources.sVATClass).Definition("Hercules", "VATClassesArrayLookUpDataSource");
                                                });
                                            });
                                        });
                                    });

                                    tabTable.AddRow(row =>
                                    {
                                        row.AddPanel("Additional", panel =>
                                        {
                                            panel.HeaderCaption(hewResources.sAdditional);
                                            panel.AddTableLayout(panelTable =>
                                            {
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.CommissionPerc).Caption(hewResources.sSalesmanCommission);
                                                    panelTableRow.AddEmptyColumn();
                                                });
                                            });
                                        });
                                    });

                                    tabTable.AddRow(panelTableRow =>
                                    {
                                        panelTableRow.AddSwitchFor(model => model.Active).Caption(hewResources.sActive);
                                    });

                                });
                                stack.AddTableLayout(tabTable =>
                                {
                                    tabTable.AddRow(row =>
                                    {
                                        row.AddPanel("ProposedQuantity", panel =>
                                        {
                                            panel.HeaderCaption(hewResources.sProposedQuantity);
                                            panel.AddTableLayout(panelTable =>
                                            {
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.SalesPropQuan).Caption(hewResources.sSales);
                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.PurPropQuan).Caption(hewResources.sPurchase);

                                                });
                                            });
                                        });
                                    });
                                    tabTable.AddRow(row =>
                                    {
                                        row.AddPanel("Behaviour", panel =>
                                        {
                                            panel.HeaderCaption(hewResources.sBehaviour);
                                            panel.AddTableLayout(panelTable =>
                                            {
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddDropDownListFor(model => model.BlockSales)
                                                        .Caption(hewResources.sItemBlockSales)
                                                        .RemoteDataSource("GetItemSalPurBehvr", this.FormController)
                                                        .ValueField("Value")
                                                        .TextField("Text");
                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddDropDownListFor(model => model.BlockPurchases)
                                                        .Caption(hewResources.sItemBlockPurchases)
                                                        .RemoteDataSource("GetItemSalPurBehvr", this.FormController)
                                                        .ValueField("Value")
                                                        .TextField("Text");
                                                });

                                            });
                                        });
                                    });
                                });
                            });
                        });
                        tabStrip.AddTab(tab =>
                        {
                            tab.Caption(hewResources.sPricingPolicy);
                            tab.AddTableLayout(tabTable =>
                            {
                                tabTable.AddRow(row =>
                                {
                                    row.AddStackLayout(powStackLayoutOrientation.Horizontal, stack =>
                                    {

                                        stack.AddPanel("Prices", panel =>
                                        {
                                            panel.AddCssClass("services-panel-prices");
                                            panel.HeaderCaption(hewResources.sPrices);
                                            panel.AddTableLayout(panelTable =>
                                            {
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.RetailPrice).Caption(hewResources.sRetail);
                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.WholesalesPrice).Caption(hewResources.sWholesales);
                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddArrayLookUpFor(model => model.CalcFromValue).Caption(hewResources.sCalculationFromValue)
                                                      .Definition("Hercules", "ItemCalcFromValueArrayLookUpDataSource");
                                                });

                                            });
                                        });

                                        stack.AddPanel("MarkUp", panel =>
                                        {
                                            panel.AddCssClass("services-panel-markup");
                                            panel.HeaderCaption(hewResources.sMarkUp);
                                            panel.Id("services__markup-panel");
                                            panel.AddTableLayout(panelTable =>
                                            {
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.RetailMarkUp).Caption(hewResources.sRetail);

                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.WholesalesMarkUp).Caption(hewResources.sWholesales);
                                                });
                                                panelTable.AddEmptyRow();


                                            });
                                        });

                                        stack.AddPanel("Discounts", panel =>
                                        {
                                            panel.Id("services__discounts-panel");
                                            panel.HeaderCaption(hewResources.sDiscounts);
                                            panel.AddTableLayout(panelTable =>
                                            {
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.RetDiscount).Caption(hewResources.sRetail);
                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.Discount).Caption(hewResources.sWholesales);
                                                });
                                                panelTable.AddRow(panelTableRow =>
                                                {
                                                    panelTableRow.AddNumericTextBoxFor(model => model.MaxDiscount).Caption(hewResources.sMaximumDiscount);
                                                });


                                            });

                                        });


                                    });

                                });
                                tabTable.AddRow(row =>
                                {
                                    row.AddPanel("Zones", panel =>
                                    {
                                        panel.HeaderCaption(hewResources.sZones);
                                        panel.AddTableLayout(panelTable =>
                                        {
                                            panelTable.AddRow(panelTableRow =>
                                            {
                                                panelTableRow.AddArrayLookUpFor(model => model.TitzID).Caption(hewResources.sTemplate).Definition("Hercules", "TemplItemPriceZonesAthenaArrayLookUpDataSource");
                                                panelTableRow.AddEmptyColumn();

                                            });
                                        });
                                    });
                                });
                                tabTable.AddRow(row =>
                                {
                                    row.AddPanel("ItemPriceZones", panel =>
                                    {
                                        panel.HeaderCaption(hewResources.sItemPriceZones);
                                        panel.AddCssClass("no-padding");
                                        panel.AddGridFor(model => model.ItemPriceZone.ZonePricesList)
                                                    .Id("InLineGridZonePrices")
                                                    .Height(600)
                                                    .PageSize(20)
                                                    .ModelIDPropertyName(x => x.PriceType)
                                                    .AddColumnFor(model => model.Description, hewResources.sDescription, c => c.Editable(false))
                                                        .AddColumnFor(model => model.Price01, GetPriceZoneDescription(1), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                        .AddColumnFor(model => model.Price02, GetPriceZoneDescription(2), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                        .AddColumnFor(model => model.Price03, GetPriceZoneDescription(3), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                        .AddColumnFor(model => model.Price04, GetPriceZoneDescription(4), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                        .AddColumnFor(model => model.Price05, GetPriceZoneDescription(5), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                        .AddColumnFor(model => model.Price06, GetPriceZoneDescription(6), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                        .AddColumnFor(model => model.Price07, GetPriceZoneDescription(7), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                        .AddColumnFor(model => model.Price08, GetPriceZoneDescription(8), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                        .AddColumnFor(model => model.Price09, GetPriceZoneDescription(9), c =>
                                                            c.Width(120).SetNumericTextEditor().Editable("function(e) { return ServicesAthenaEdit.EditGridHandler(e); }"))
                                                    .LocalDataSource(dataSource =>
                                                        dataSource.LocalDataSourceFiltersHandler("ServicesAthenaEdit.FilterInLineGridZonePrices"))
                                                    .ShowDefaultCreateButton(false)
                                                    .AddToolbarButton("clearPriceZones", button =>
                                                        button.Tooltip(hewResources.sClearAll)
                                                              .AddIconCssClass("fa fa-trash")
                                                              .Events(events => events.Click("function() { ServicesAthenaEdit.ClearZones(); }")))
                                                    .ShowDefaultDestroyButton(false);
                                    });
                                });
                            });

                        });
                        tabStrip.AddTab(tab =>
                        {
                            tab.Caption(hewResources.sAdditional);
                            tab.AddStackLayout(powStackLayoutOrientation.Vertical, tabStack =>
                            {
                                tabStack.AddPanel("SpecialBehaviourPanel", panel =>
                                {
                                    panel.HeaderCaption(hewResources.sSpecialBehaviour);
                                    panel.AddStackLayout(powStackLayoutOrientation.Horizontal, specialBehaviourStack =>
                                    {
                                        specialBehaviourStack.AddPanel("SalesPanel", salesPanel =>
                                        {
                                            salesPanel.HeaderCaption(hewResources.sSales);
                                            salesPanel.AddStackLayout(powStackLayoutOrientation.Vertical, salesStack =>
                                            {
                                                salesStack.AddSwitchFor(model => model.NotApplSalDisc)
                                                    .Caption(hewResources.sNotApplliedSalesDiscounts);
                                                salesStack.AddArrayLookUpFor(model => model.NotApplSalAddChrg)
                                                    .Caption(hewResources.sNotApplliedSalesAddCharges)
                                                    .Definition("Hercules", "ItemNotApplAddChrgEnumArrayLookupDataSource");
                                            });
                                        });
                                        specialBehaviourStack.AddPanel("PurchacesPanel", purchacesPanel =>
                                        {
                                            purchacesPanel.HeaderCaption(hewResources.sPurchases);
                                            purchacesPanel.AddStackLayout(powStackLayoutOrientation.Vertical, purchacesStack =>
                                            {
                                                purchacesStack.AddSwitchFor(model => model.NotApplPurDisc).Caption(hewResources.sNotApplliedPurchasesDiscounts);
                                                purchacesStack.AddArrayLookUpFor(model => model.NotApplPurAddChrg).Caption(hewResources.sNotApplliedPurchasesAddCharges).Definition("Hercules", "ItemNotApplAddChrgEnumArrayLookupDataSource");
                                            });

                                        });
                                    });
                                });
                                tabStack.AddPanel("UserDefinedFields", panel =>
                                {
                                    var arrayCategories = base.AppContext.CallObjectMethod<List<string>>("Hercules", "UserDefinedOperations.Web", "GetUserDefinedFieldDescriptions", UserDefinedTypeEnum.Category, UserDefinedClassEnum.Items, new List<int> { 1, 2 });
                                    var arrayTexts = base.AppContext.CallObjectMethod<List<string>>("Hercules", "UserDefinedOperations.Web", "GetUserDefinedFieldDescriptions", UserDefinedTypeEnum.Text, UserDefinedClassEnum.Items, new List<int> { 1, 2 });
                                    var arrayBools = base.AppContext.CallObjectMethod<List<string>>("Hercules", "UserDefinedOperations.Web", "GetUserDefinedFieldDescriptions", UserDefinedTypeEnum.Bool, UserDefinedClassEnum.Items, new List<int> { 1, 2 });
                                    var arrayNums = base.AppContext.CallObjectMethod<List<string>>("Hercules", "UserDefinedOperations.Web", "GetUserDefinedFieldDescriptions", UserDefinedTypeEnum.Num, UserDefinedClassEnum.Items, new List<int> { 1, 2 });
                                    var arrayDates = base.AppContext.CallObjectMethod<List<string>>("Hercules", "UserDefinedOperations.Web", "GetUserDefinedFieldDescriptions", UserDefinedTypeEnum.Date, UserDefinedClassEnum.Items, new List<int> { 1, 2 });

                                    panel.HeaderCaption(hewResources.sUserDefinedFields);
                                    panel.AddTableLayout(tabTable =>
                                    {
                                        tabTable.AddRow(row =>
                                        {
                                            row.AddArrayLookUpFor(model => model.Cat01ID).Definition("Hercules", "ItemsAthenaCategories01LookUpDataSource").Caption(arrayCategories[0]).Id("Cat00");
                                            row.AddTextBoxFor(model => model.UserDefText01).Caption(arrayTexts[0]);
                                        });
                                        tabTable.AddRow(row =>
                                        {
                                            row.AddArrayLookUpFor(model => model.Cat02ID).Definition("Hercules", "ItemsAthenaCategories02LookUpDataSource").Caption(arrayCategories[1]).Id("Cat01");
                                            row.AddTextBoxFor(model => model.UserDefText02).Caption(arrayTexts[1]);
                                        });
                                        tabTable.AddRow(row =>
                                        {
                                            row.AddNumericTextBoxFor(model => model.UserDefNum01).Caption(arrayNums[0]);
                                            row.AddDatePickerFor(model => model.UserDefDate01).Caption(arrayDates[0]);
                                            row.AddSwitchFor(model => model.UserDefBool01).Caption(arrayBools[0]).LayoutWeight(2);
                                        });
                                        tabTable.AddRow(row =>
                                        {
                                            row.AddNumericTextBoxFor(model => model.UserDefNum02).Caption(arrayNums[1]);
                                            row.AddDatePickerFor(model => model.UserDefDate02).Caption(arrayDates[1]);
                                            row.AddSwitchFor(model => model.UserDefBool02).Caption(arrayBools[1]).LayoutWeight(2);
                                        });
                                    });
                                });
                                tabStack.AddTextAreaFor(model => model.Comments).Caption(hewResources.sComments).Height(260);
                            });
                        });
                    });
                });
            });
        }
    }
}
