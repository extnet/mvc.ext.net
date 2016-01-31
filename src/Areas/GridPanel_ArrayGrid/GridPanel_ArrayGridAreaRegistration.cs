using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ArrayGrid
{
    public class GridPanel_ArrayGridAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_ArrayGrid";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_ArrayGrid_default",
                "GridPanel_ArrayGrid/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
