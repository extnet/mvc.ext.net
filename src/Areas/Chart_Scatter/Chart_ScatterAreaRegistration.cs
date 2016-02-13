using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Scatter
{
    public class Chart_ScatterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Scatter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Scatter_default",
                "Chart_Scatter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
