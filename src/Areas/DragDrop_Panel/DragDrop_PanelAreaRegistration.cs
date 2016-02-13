using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DragDrop_Panel
{
    public class DragDrop_PanelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DragDrop_Panel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DragDrop_Panel_default",
                "DragDrop_Panel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
