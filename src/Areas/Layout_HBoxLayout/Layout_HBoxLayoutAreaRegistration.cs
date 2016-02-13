using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_HBoxLayout
{
    public class Layout_HBoxLayoutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Layout_HBoxLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Layout_HBoxLayout_default",
                "Layout_HBoxLayout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
