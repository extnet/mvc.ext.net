using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_TextBlock
{
    public class Miscellaneous_TextBlockAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_TextBlock";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_TextBlock_default",
                "Miscellaneous_TextBlock/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
