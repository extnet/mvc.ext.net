using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Panel_Basic {
    public class Panel_BasicAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "Panel_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Panel_Basic_default",
                "Panel_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
