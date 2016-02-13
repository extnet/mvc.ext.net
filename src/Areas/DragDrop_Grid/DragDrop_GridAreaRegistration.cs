using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Grid
{
    public class DragDrop_GridAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DragDrop_Grid";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DragDrop_Grid_default",
                "DragDrop_Grid/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
