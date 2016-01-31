using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander
{
    public class GridPanel_RowExpanderAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_RowExpander";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_RowExpander_default",
                "GridPanel_RowExpander/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
