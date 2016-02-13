using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Column
{
    public class Chart_ColumnAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Column";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Column_default",
                "Chart_Column/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
