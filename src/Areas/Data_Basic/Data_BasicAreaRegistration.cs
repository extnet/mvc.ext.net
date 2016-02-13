using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Data_Basic
{
    public class Data_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Data_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Data_Basic_default",
                "Data_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
