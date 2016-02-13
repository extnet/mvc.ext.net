using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Line
{
    public class Chart_LineAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Line";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Line_default",
                "Chart_Line/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
