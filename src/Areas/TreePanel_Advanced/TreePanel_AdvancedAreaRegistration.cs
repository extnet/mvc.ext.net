using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Advanced
{
    public class TreePanel_AdvancedAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TreePanel_Advanced";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TreePanel_Advanced_default",
                "TreePanel_Advanced/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
