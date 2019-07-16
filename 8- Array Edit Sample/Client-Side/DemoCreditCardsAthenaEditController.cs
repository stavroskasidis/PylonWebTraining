using Hercules.Libs.Web.Client.ControllerOptions;
using Hercules.Libs.Web.Client.Controllers;
using Hercules.Obj.Web.FIN.DataObjectProxies.CreditCards;
using Poseidon.Libs.Web.Base.ViewModels;
using Poseidon.Libs.Web.Client;
using Poseidon.Libs.Web.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.ATH.Web.Arrays
{
    [powAuthorizeActions(typeof(hewCreditCardsAthenaAction))]
    public class hewDemoCreditCardsAthenaEditController :
        hewArrayEditCodeNameController<hewCreditCardsDataObjectProxy, powArrayEditViewModel>
    {
        protected override string Name => "CreditCards";
        protected override string ViewName => "Demo.CreditCards.Athena.Edit";
        protected override void SetPageOptions(hewPageOptionsBuilder builder)
        {
            builder.Title(hewResources.sCreditCards);
        }

        protected override OperationResult UpdateExistingObjectValues(hewCreditCardsDataObjectProxy oldValues, hewCreditCardsDataObjectProxy newValues)
        {
            oldValues.BankID = newValues.BankID;
            oldValues.AccPrefix01 = newValues.AccPrefix01;
            oldValues.Active = newValues.Active;

            return base.UpdateExistingObjectValues(oldValues, newValues);
        }
    }
}
