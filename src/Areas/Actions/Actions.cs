using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Actions
{
    public class Actions : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Actions";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Actions_default",
                "Actions/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
