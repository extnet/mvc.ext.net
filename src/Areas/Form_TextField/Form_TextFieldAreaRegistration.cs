using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_TextField
{
    public class Form_TextFieldAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_TextField";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                AreaName + "_default",
                AreaName + "/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
