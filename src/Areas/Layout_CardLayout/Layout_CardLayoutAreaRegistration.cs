using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_CardLayout
{
    public class Layout_CardLayoutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Layout_CardLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Layout_CardLayout_default",
                "Layout_CardLayout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
