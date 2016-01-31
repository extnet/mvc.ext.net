using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Update
{
    public class GridPanel_UpdateAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Update";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Update_default",
                "GridPanel_Update/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
