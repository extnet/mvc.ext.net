using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic
{
    public class TreePanel_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TreePanel_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TreePanel_Basic_default",
                "TreePanel_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
