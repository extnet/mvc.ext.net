using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_FitLayout
{
    public class Layout_FitLayoutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Layout_FitLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Layout_FitLayout_default",
                "Layout_FitLayout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
