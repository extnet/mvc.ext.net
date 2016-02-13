using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_MultiSelect.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubmitSelection1()
        {
            List<ListItem> items = JSON.Deserialize<List<ListItem>>(Request.Params["items"]);
            StringBuilder sb = new StringBuilder(256);
            sb.Append("Ext.Msg.alert('Selection', '");

            foreach (Ext.Net.ListItem item in items)
            {
                sb.AppendFormat("Value={0}, Index={1}, Text={2} <br/>", item.Value, item.Index, item.Text);
            }

            sb.Append("');");

            X.AddScript(sb.ToString());

            return this.Direct();
        }
    }
}
