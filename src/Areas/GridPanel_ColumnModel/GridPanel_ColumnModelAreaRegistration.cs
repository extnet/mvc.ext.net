using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ColumnModel
{
    public class GridPanel_ColumnModelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_ColumnModel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_ColumnModel_default",
                "GridPanel_ColumnModel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
