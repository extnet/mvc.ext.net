using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_ColumnLayout
{
    public class Layout_ColumnLayoutAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Layout_ColumnLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Layout_ColumnLayout_default",
                "Layout_ColumnLayout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
