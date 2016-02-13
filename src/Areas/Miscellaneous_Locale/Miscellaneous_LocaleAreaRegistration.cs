using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Locale
{
    public class Miscellaneous_LocaleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_Locale";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_Locale_default",
                "Miscellaneous_Locale/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
