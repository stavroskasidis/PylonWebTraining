using Hercules.Libs.Web.Client.Controllers;
using Hercules.Libs.Web.UI.Client.SystemViews;
using Hercules.Libs.Web.UI.Client.ViewModels;
using Poseidon.Libs.Web.Client;
using Poseidon.Libs.Web.UI.Client;
using Poseidon.Libs.Web.UI.ContextMenuBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hercules.Libs.Web.UI.Client.Controllers
{
    public class hewDemoController : hewBaseController
    {
        protected override void SetContextMenu(powContextMenuBuilder contextMenu)
        {
            contextMenu.AddNode("Save", node => node.OnClick("function(){ demoIndex.OnSaveClick(); }"));
        }

        public ActionResult Index()
        {
            this.PageTitle = this.ContextMenuTitle = "Demo";

            var model = new hewDemoIndexViewModel();
            model.Active = true;
            model.Description = "...";

            return PoseidonSystemView<hewDemoIndex>(model);
        }

        [HttpPost]
        public powAjaxActionResult Save(hewDemoIndexViewModel model)
        {
            //TODO: Save to db

            return AjaxActionSuccess();
        }



        public ActionResult GetNeedsDateEnum()
        {
            return Json(new[]
            {
                new
                {
                    Value = NeedsDate.Yes,
                    Text = "Yes"
                },
                new
                {
                    Value = NeedsDate.No,
                    Text = "No"
                },
                new
                {
                    Value = NeedsDate.Maybe,
                    Text = "Maybe"
                },
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
