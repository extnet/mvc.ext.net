using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_AbsoluteLayout
{
    public class Layout_AbsoluteLayoutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Layout_AbsoluteLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Layout_AbsoluteLayout_default",
                "Layout_AbsoluteLayout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
