using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Paging_and_Sorting
{
    public class GridPanel_Paging_and_SortingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Paging_and_Sorting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Paging_and_Sorting_default",
                "GridPanel_Paging_and_Sorting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
