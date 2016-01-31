using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Items
{
    public class ItemsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Items";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Items_default",
                "Items/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
