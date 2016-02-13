using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.MessageBox_Basic
{
    public class MessageBox_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MessageBox_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MessageBox_Basic_default",
                "MessageBox_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
