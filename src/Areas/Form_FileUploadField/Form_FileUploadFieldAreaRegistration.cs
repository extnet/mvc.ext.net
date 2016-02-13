using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_FileUploadField
{
    public class Form_FileUploadFieldAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Form_FileUploadField";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Form_FileUploadField_default",
                "Form_FileUploadField/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
