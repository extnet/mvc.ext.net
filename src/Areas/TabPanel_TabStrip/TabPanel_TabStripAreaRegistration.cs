using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TabPanel_TabStrip
{
    public class TabPanel_TabStripAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TabPanel_TabStrip";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TabPanel_TabStrip_default",
                "TabPanel_TabStrip/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
