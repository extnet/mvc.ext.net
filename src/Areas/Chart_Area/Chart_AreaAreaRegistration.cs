using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Area
{
    public class Chart_AreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Area";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Area_default",
                "Chart_Area/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
