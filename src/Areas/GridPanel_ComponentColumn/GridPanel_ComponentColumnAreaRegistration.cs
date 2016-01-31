using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ComponentColumn
{
    public class GridPanel_ComponentColumnAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_ComponentColumn";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_ComponentColumn_default",
                "GridPanel_ComponentColumn/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
