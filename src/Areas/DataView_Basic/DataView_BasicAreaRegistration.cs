using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DataView_Basic
{
    public class DataView_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DataView_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DataView_Basic_default",
                "DataView_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
