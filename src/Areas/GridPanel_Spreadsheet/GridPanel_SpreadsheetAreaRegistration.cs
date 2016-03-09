using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Spreadsheet
{
    public class GridPanel_SpreadsheetAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Spreadsheet";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Spreadsheet_default",
                "GridPanel_Spreadsheet/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
