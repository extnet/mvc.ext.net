using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Associations_HasMany
{
    public class Associations_HasManyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Associations_HasMany";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Associations_HasMany_default",
                "Associations_HasMany/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
