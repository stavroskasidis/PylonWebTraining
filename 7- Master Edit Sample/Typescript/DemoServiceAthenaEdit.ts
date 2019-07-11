namespace hewClientScripts.ATH.Masters.Items {

    export class DemoServicesAthenaEdit implements powClientScripts.System.IEntryPoint {

        private proxy: hewClientScripts.DataObjects.ItemsDataObject.ItemsDataObjectProxy;

        OnInit() {
            this.proxy = hewClientScripts.Libs.Helpers.CreateDataObjectProxy($("#servicesEditForm"),
                hewClientScripts.DataObjects.ItemsDataObject.ItemsDataObjectProxy);

            this.proxy.Observable.bind("change", (e: kendo.data.ObservableObjectEvent) => this.onPropertyChange(e));
            $(() => {
                this.onNotApplSalDiscChange();
                this.checkGridValues();
            });
        }

        private onPropertyChange(e: kendo.data.ObservableObjectEvent): void {
            if (e.field == "NotApplSalDisc") {
                this.onNotApplSalDiscChange();
            }
            else if (e.field == "TitzID" && this.proxy.TitzID) {
                this.ClearZones();
            }
            else if (e.field.indexOf("ItemPriceZone.ZonePricesList.Price") > -1) {
                this.checkGridValues();
            }
        }

        private onNotApplSalDiscChange() {
            if (this.proxy.NotApplSalDisc) {
                this.proxy.RetDiscount = 0;
                powClientScripts.Helpers.UI.SetComponentEnabled($("input[name='RetDiscount']"), false);
                this.proxy.Discount = 0;
                powClientScripts.Helpers.UI.SetComponentEnabled($("input[name='Discount']"), false);
                this.proxy.MaxDiscount = 0;
                powClientScripts.Helpers.UI.SetComponentEnabled($("input[name='MaxDiscount']"), false);
            }
            else {
                powClientScripts.Helpers.UI.SetComponentEnabled($("input[name='RetDiscount']"), true);
                powClientScripts.Helpers.UI.SetComponentEnabled($("input[name='Discount']"), true);
                powClientScripts.Helpers.UI.SetComponentEnabled($("input[name='MaxDiscount']"), true);
            }
        }

        public ClearZones(): void {
            let self = this;

            let zonesPricesList = self.proxy.ItemPriceZone.ZonePricesList;
            zonesPricesList.removeAll();

            let retailZone = new hewClientScripts.DataObjects.ItemsDataObject.ZonePrices(null, self.proxy.ItemPriceZone);
            retailZone.PriceType = hewClientScripts.DataObjects.ItemsDataObject.PriceRowTypeEnum.Retail;
            retailZone.Description = Resources.Hercules_ATH_Masters.sRetail;

            let retailMarkUpZone = new hewClientScripts.DataObjects.ItemsDataObject.ZonePrices(null, self.proxy.ItemPriceZone);
            retailMarkUpZone.PriceType = hewClientScripts.DataObjects.ItemsDataObject.PriceRowTypeEnum.RetailMarkup;
            retailMarkUpZone.Description = Resources.Hercules_ATH_Masters.sRetailMarkup;

            let wholesaleZone = new hewClientScripts.DataObjects.ItemsDataObject.ZonePrices(null, self.proxy.ItemPriceZone);
            wholesaleZone.PriceType = hewClientScripts.DataObjects.ItemsDataObject.PriceRowTypeEnum.Wholesale;
            wholesaleZone.Description = Resources.Hercules_ATH_Masters.sWholesale;

            let wholesaleMarkupZone = new hewClientScripts.DataObjects.ItemsDataObject.ZonePrices(null, self.proxy.ItemPriceZone);
            wholesaleMarkupZone.PriceType = hewClientScripts.DataObjects.ItemsDataObject.PriceRowTypeEnum.WholesaleMarkup;
            wholesaleMarkupZone.Description = Resources.Hercules_ATH_Masters.sWholesaleMarkup;

            zonesPricesList.add(retailZone);
            zonesPricesList.add(retailMarkUpZone);
            zonesPricesList.add(wholesaleZone);
            zonesPricesList.add(wholesaleMarkupZone);

            powClientScripts.Helpers.UI.SetComponentEnabled($("input[name='TitzID']"), true);
            powClientScripts.PageContext.IsDirty = true;
        }

        private checkGridValues() {
            let enabled = true;
            for (let item of this.proxy.ItemPriceZone.ZonePricesList) {
                if (item.Price01 || item.Price01 == 0
                    || item.Price01 || item.Price01 == 0
                    || item.Price02 || item.Price02 == 0
                    || item.Price03 || item.Price03 == 0
                    || item.Price04 || item.Price04 == 0
                    || item.Price05 || item.Price05 == 0
                    || item.Price06 || item.Price06 == 0
                    || item.Price07 || item.Price07 == 0
                    || item.Price08 || item.Price08 == 0
                    || item.Price09 || item.Price09 == 0) {

                    enabled = false;
                    break;
                }
            }
            powClientScripts.Helpers.UI.SetComponentEnabled($("input[name='TitzID']"), enabled);
        }

        public FilterInLineGridZonePrices(): kendo.data.DataSourceFilters {
            return {
                logic: "or",
                filters: [
                    {
                        field: "PriceType",
                        operator: "eq",
                        value: hewClientScripts.DataObjects.ItemsDataObject.PriceRowTypeEnum.Retail
                    }, {
                        field: "PriceType",
                        operator: "eq",
                        value: hewClientScripts.DataObjects.ItemsDataObject.PriceRowTypeEnum.Wholesale
                    }
                ]
            };
        }

        public EditGridHandler() {
            return !this.proxy.TitzID;
        }
    }
}