using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Commands
{
    public class GridPanel_CommandsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Commands";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Commands_default",
                "GridPanel_Commands/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
