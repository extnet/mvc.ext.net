using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Basic
{
    public class DragDrop_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DragDrop_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DragDrop_Basic_default",
                "DragDrop_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
