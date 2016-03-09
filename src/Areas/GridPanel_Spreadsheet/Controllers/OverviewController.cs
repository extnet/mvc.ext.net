using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Spreadsheet.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Spreadsheet.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return this.View(GridPanel_SpreadsheetOverviewModel.GetData());
        }

        public ActionResult Reload()
        {
            return this.Store(GridPanel_SpreadsheetOverviewModel.GetData());
        }
    }
}
