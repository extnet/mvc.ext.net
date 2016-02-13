using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_MultiSelect
{
    public class Form_MultiSelectAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_MultiSelect";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Form_MultiSelect_default",
                "Form_MultiSelect/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
