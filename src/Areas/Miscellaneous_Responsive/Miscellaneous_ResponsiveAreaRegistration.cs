using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Responsive
{
    public class Miscellaneous_ResponsiveAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_Responsive";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_Responsive_default",
                "Miscellaneous_Responsive/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
