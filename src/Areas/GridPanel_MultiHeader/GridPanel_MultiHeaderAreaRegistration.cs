using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_MultiHeader
{
    public class GridPanel_MultiHeaderAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_MultiHeader";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_MultiHeader_default",
                "GridPanel_MultiHeader/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
