using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Panel_BodyMask
{
    public class Panel_BodyMaskAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Panel_BodyMask";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Panel_BodyMask_default",
                "Panel_BodyMask/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
