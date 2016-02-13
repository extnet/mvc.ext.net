using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_VBoxLayout
{
    public class Layout_VBoxLayoutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Layout_VBoxLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Layout_VBoxLayout_default",
                "Layout_VBoxLayout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
