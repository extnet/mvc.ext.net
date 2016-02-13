using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_AnchorLayout
{
    public class Layout_AnchorLayoutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Layout_AnchorLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Layout_AnchorLayout_default",
                "Layout_AnchorLayout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
