using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Models
{
    public class ModelsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Models";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Models_default",
                "Models/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
