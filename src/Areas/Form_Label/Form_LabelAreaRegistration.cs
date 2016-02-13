using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_Label
{
    public class Form_LabelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_Label";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Form_Label_default",
                "Form_Label/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
