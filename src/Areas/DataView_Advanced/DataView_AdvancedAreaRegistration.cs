using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DataView_Advanced
{
    public class DataView_AdvancedAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DataView_Advanced";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DataView_Advanced_default",
                "DataView_Advanced/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
