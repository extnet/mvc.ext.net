using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Editable
{
    public class GridPanel_EditableAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Editable";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Editable_default",
                "GridPanel_Editable/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
