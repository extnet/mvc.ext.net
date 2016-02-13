using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Panel_Miscellaneous
{
    public class Panel_MiscellaneousAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Panel_Miscellaneous";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Panel_Miscellaneous_default",
                "Panel_Miscellaneous/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
