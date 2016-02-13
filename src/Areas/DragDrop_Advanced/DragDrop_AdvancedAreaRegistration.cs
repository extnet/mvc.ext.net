using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Advanced
{
    public class DragDrop_AdvancedAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DragDrop_Advanced";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DragDrop_Advanced_default",
                "DragDrop_Advanced/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
