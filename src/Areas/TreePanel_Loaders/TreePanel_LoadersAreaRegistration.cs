using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Loaders
{
    public class TreePanel_LoadersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TreePanel_Loaders";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TreePanel_Loaders_default",
                "TreePanel_Loaders/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
