using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Pie
{
    public class Chart_PieAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Pie";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Pie_default",
                "Chart_Pie/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
