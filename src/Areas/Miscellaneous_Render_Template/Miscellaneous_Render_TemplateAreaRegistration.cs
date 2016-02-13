using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Render_Template
{
    public class Miscellaneous_Render_TemplateAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_Render_Template";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_Render_Template_default",
                "Miscellaneous_Render_Template/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
