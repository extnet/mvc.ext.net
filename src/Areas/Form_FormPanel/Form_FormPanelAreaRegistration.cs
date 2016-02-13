using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_FormPanel
{
    public class Form_FormPanelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_FormPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Form_FormPanel_default",
                "Form_FormPanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
