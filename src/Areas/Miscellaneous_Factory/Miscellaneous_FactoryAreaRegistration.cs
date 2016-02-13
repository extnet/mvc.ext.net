using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Factory
{
    public class Miscellaneous_FactoryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_Factory";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_Factory_default",
                "Miscellaneous_Factory/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
