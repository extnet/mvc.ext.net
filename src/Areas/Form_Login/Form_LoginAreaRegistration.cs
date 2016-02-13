using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_Login
{
    public class Form_LoginAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_Login";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Form_Login_default",
                "Form_Login/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
