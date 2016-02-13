using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_Groups
{
    public class Form_GroupsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_Groups";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Form_Groups_default",
                "Form_Groups/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
