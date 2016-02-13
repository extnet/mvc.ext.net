using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Bar
{
    public class Chart_BarAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Bar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Bar_default",
                "Chart_Bar/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
