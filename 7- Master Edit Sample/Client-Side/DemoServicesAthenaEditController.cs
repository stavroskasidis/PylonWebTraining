using Hercules.Libs.Web.Client.ControllerOptions;
using Hercules.Libs.Web.Client.Controllers;
using Hercules.Obj.Web.COM.DataObjectProxies.PriceZones;
using Hercules.Obj.Web.STH.DataObjectProxies.Item;
using Poseidon.Libs.Web.Client;
using Poseidon.Libs.Web.Client.Attributes;
using Poseidon.Libs.Web.Client.JavascriptResources;
using Poseidon.Libs.Web.UI.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Web.Masters.Items
{
    [powAuthorizeActions(typeof(hewServicesAthenaAction))]
    public class hewDemoServicesAthenaEditController : hewMasterEditController<hewItemsDataObjectProxy>
    {
        protected override string BrowserControllerName => "hewDemoServicesAthena";

        protected override string LogicalObjectName => "Hercules;Services";

        protected override string EditViewName => "Demo.Services.Athena.Edit";

        protected override void OnSave(hewItemsDataObjectProxy model, powStorageObject<hewItemsDataObjectProxy> transactionObject, bool isSaveAndClose)
        {
            transactionObject.Data = model;
        }

        protected override void SetPageOptions(hewPageOptionsBuilder builder)
        {
            builder.Title("Services Edit");
        }

        protected override void OnModelInit(hewItemsDataObjectProxy model)
        {
            base.OnModelInit(model);
            if (model.IsNew)
            {
                model.ItemPriceZone = new hewItemPriceZone()
                {
                    ItemID = model.ID
                };
            }
            else
            {
                var itemriceZoneOperation = powWebAppContext.Current.AppServer.CallMethod<hewItemPriceZone>("Hercules", "WebMasterOperations", "GetItemPriceZoneInfo", model.ID);
                itemriceZoneOperation.EnsureOperationSuccess();
                model.ItemPriceZone = itemriceZoneOperation.Result;
            }
        }
        protected override void RegisterJavascriptResources(List<powJavascriptResourceRegistration> jsResourcesRegistrations)
        {
            base.RegisterJavascriptResources(jsResourcesRegistrations);
            jsResourcesRegistrations.Add(new powJavascriptResourceRegistration("Hercules_ATH_Masters", typeof(hewJSResources)));
        }

        public powAjaxActionResult GetItemSalPurBehvr()
        {
            var data = new Dictionary<hewItemsDataObjectProxy.ItemSalPurBehvrEnum, string>
            {
                {hewItemsDataObjectProxy.ItemSalPurBehvrEnum.No, hewResources.sNo},
                {hewItemsDataObjectProxy.ItemSalPurBehvrEnum.Yes, hewResources.sYes},
            };

            var result = data.Select(x => new { Text = x.Value, Value = (int)x.Key });
            return AjaxActionSuccess(result);
        }
    }
}
