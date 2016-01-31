using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Plugins
{
    public class GridPanel_PluginsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Plugins";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Plugins_default",
                "GridPanel_Plugins/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
