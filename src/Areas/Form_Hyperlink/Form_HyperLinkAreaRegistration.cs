using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_Hyperlink
{
    public class Form_HyperlinkAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_Hyperlink";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Form_Hyperlink_default",
                "Form_Hyperlink/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
