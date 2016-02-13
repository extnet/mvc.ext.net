using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TabPanel_Basic
{
    public class TabPanel_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TabPanel_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TabPanel_Basic_default",
                "TabPanel_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
