using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_List
{
    public class TreePanel_ListAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "TreePanel_List";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "TreePanel_List_default",
                "TreePanel_List/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
