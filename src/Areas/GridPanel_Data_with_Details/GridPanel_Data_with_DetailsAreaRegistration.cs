using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_with_Details
{
    public class GridPanel_Data_with_DetailsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Data_with_Details";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Data_with_Details_default",
                "GridPanel_Data_with_Details/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
