using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Infinite_Scrolling
{
    public class GridPanel_Infinite_ScrollingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Infinite_Scrolling";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Infinite_Scrolling_default",
                "GridPanel_Infinite_Scrolling/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
