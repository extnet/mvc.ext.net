using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_History
{
    public class Miscellaneous_HistoryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_History";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_History_default",
                "Miscellaneous_History/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
