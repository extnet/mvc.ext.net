using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Keys_KeyNav
{
    public class Keys_KeyNavAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Keys_KeyNav";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Keys_KeyNav_default",
                "Keys_KeyNav/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
