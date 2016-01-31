using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Miscellaneous
{
    public class GridPanel_MiscellaneousAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Miscellaneous";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Miscellaneous_default",
                "GridPanel_Miscellaneous/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
