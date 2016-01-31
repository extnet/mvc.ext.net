using System;
using System.Text;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Selection_Models.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Selection_Models.Controllers
{
    public class Checkbox_SelectionController : Controller
    {
        public ActionResult Index()
        {
            return View(new Checkbox_SelectionModel());
        }

        public ActionResult Submit(string selection)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<b>Selected Rows (ids)</b></br /><ul>");
            SelectedRowCollection src = JSON.Deserialize<SelectedRowCollection>(selection);

            foreach (SelectedRow row in src)
            {
                result.Append("<li>" + row.RecordID + "</li>");
            }

            result.Append("</ul>");
            X.GetCmp<Label>("Label1").Html = result.ToString();

            return this.Direct();
        }
    }
}
