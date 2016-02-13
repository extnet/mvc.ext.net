using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_ClickRepeater
{
    public class Miscellaneous_ClickRepeaterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_ClickRepeater";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_ClickRepeater_default",
                "Miscellaneous_ClickRepeater/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
