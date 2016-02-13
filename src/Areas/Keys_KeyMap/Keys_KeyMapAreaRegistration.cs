using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Keys_KeyMap
{
    public class Keys_KeyMapAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Keys_KeyMap";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Keys_KeyMap_default",
                "Keys_KeyMap/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
