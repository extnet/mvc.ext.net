using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_FilterHeader
{
    public class GridPanel_FilterHeaderAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_FilterHeader";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_FilterHeader_default",
                "GridPanel_FilterHeader/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
