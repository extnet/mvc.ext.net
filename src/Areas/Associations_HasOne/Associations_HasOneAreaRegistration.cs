using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Associations_HasOne
{
    public class Associations_HasOneAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Associations_HasOne";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Associations_HasOne_default",
                "Associations_HasOne/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
