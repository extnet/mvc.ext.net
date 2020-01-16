using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Buttons_ButtonGroup
{
    public class Buttons_ButtonGroupAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Buttons_ButtonGroup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Buttons_ButtonGroup_default",
                "Buttons_ButtonGroup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
