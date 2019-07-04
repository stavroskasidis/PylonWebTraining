using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules.Libs.Web.UI.Client.ViewModels
{
    public enum NeedsDate
    {
        Yes,
        No,
        Maybe
    }

    public class hewDemoIndexViewModel
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string CustID { get; set; }
        public string VtstID { get; set; }
        public DateTime Date { get; set; }
        public NeedsDate NeedsDate { get;  set; }
        public bool Active { get; set; }
    }
}
