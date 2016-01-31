using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Selection_Models
{
    public class GridPanel_Selection_ModelsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Selection_Models";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Selection_Models_default",
                "GridPanel_Selection_Models/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
