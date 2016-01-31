using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_ComboBox
{
    public class Form_ComboBoxAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_ComboBox";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Form_ComboBox_default",
                "Form_ComboBox/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
