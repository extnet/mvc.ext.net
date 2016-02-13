using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_FlashComponent
{
    public class Miscellaneous_FlashComponentAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_FlashComponent";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_FlashComponent_default",
                "Miscellaneous_FlashComponent/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
